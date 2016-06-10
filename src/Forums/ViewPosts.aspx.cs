using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace zobuno.forums
{
    public partial class ViewPosts : System.Web.UI.Page
    {
        public ForumTopic ForumTopic { get; set; }
        ForumsDC data = new ForumsDC();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                postReply.Visible = true;

                if (helper.CurrentUser.EmailAddress == "cdunn@cidean.com")
                {
                    adminPost.Visible = true;

                    if (!IsPostBack)
                    {
                        postUser.DataSource = (from User user in data.Users
                                               select user);
                        postUser.DataBind();
                        postUser.Items.Insert(0, new ListItem("", ""));
                    }
                }
            }
            

            ForumTopic = data.ForumTopics.SingleOrDefault(m=>m.ID ==Int32.Parse(Request.QueryString["topic"]));

            if (!IsPostBack)
            {
                refreshPosts();
                DataBind();
            }
            
            returnTopics.NavigateUrl = "~/" + ForumTopic.Forum.Url;
            returnTopics.Text = "Back to " + ForumTopic.Forum.Title;
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            postList.ItemCommand += new DataListCommandEventHandler(postList_ItemCommand);
        }

        void postList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                data.ForumPosts.DeleteOnSubmit(data.ForumPosts.SingleOrDefault(m => m.ID.ToString() == e.CommandArgument.ToString()));
                data.SubmitChanges();
                refreshPosts();
            }
        }

        public helper ForumHelper()
        {
            return new helper();
        }

        public string DateToText(string dateValue)
        {
            return helper.DateToText(dateValue);
        }

        private void refreshPosts()
        {
            postList.DataSource = (from ForumPost post in data.ForumPosts
                                   where post.TopicID == Int32.Parse(Request.QueryString["topic"])
                                   orderby post.DateCreated descending
                                   select post);
            postList.DataBind();
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            postReplyMessage.Visible = false;

            if(string.IsNullOrEmpty(postDescription.Text))
            {
                postReplyMessage.Visible = true;
                return;
            }

            ForumPost post = new ForumPost();
            post.ForumID = ForumTopic.ForumID;
            post.TopicID = ForumTopic.ID;
            post.Description = helper.CleanHtml(postDescription.Text);
            if (adminPost.Visible)
            {
                if (!string.IsNullOrEmpty(postDate.Text))
                    post.DateCreated = DateTime.Parse(postDate.Text);
                else
                    post.DateCreated = DateTime.Now;

                if (!string.IsNullOrEmpty(postUser.SelectedValue))
                    post.UserID = Int32.Parse(postUser.SelectedValue);
                else
                    post.UserID = helper.CurrentUser.ID;
            }
            else
            {
                post.DateCreated = DateTime.Now;
                post.UserID = helper.CurrentUser.ID;

            }
            
            data.ForumPosts.InsertOnSubmit(post);
            data.SubmitChanges();

            postDescription.Text = "";

            refreshPosts();
        }
    }
}