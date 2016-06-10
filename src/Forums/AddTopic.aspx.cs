using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using zobuno.forums;

namespace zobuno.forums
{
    public partial class AddTopic : System.Web.UI.Page
    {

        ForumsDC data = new ForumsDC();
        Forum forum;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            forum = data.Forums.SingleOrDefault(m => m.Url == Request["forum"]);

            forumTitle.Controls.Add(new LiteralControl(forum.Title));

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

        void btnSubmit_Click(object sender, EventArgs e)
        {
            topicMessage.Visible = false;
            if (string.IsNullOrEmpty(topicTitle.Text) || string.IsNullOrEmpty(topicDescription.Text))
            {
                topicMessage.Visible = true;
                return;
            }

            

           
            ForumTopic topic = new ForumTopic();


            topic.ForumID = forum.ID;
            topic.Title = helper.CleanHtml(topicTitle.Text);
            topic.Description = helper.CleanHtml(topicDescription.Text);
            
            if (adminPost.Visible)
            {
                if (!string.IsNullOrEmpty(postDate.Text))
                    topic.DateCreated = DateTime.Parse(postDate.Text);
                else
                    topic.DateCreated = DateTime.Now;

                if (!string.IsNullOrEmpty(postUser.SelectedValue))
                    topic.UserID = Int32.Parse(postUser.SelectedValue);
                else
                    topic.UserID = helper.CurrentUser.ID;
            }
            else
            {
                topic.UserID = helper.CurrentUser.ID;
                topic.DateCreated = DateTime.Now;
            }
            topic.DateUpdated = topic.DateCreated;
            topic.LastPostDate = topic.DateCreated;
            topic.LastPostUserID = topic.UserID;


            data.ForumTopics.InsertOnSubmit(topic);
            data.SubmitChanges();

            Response.Redirect("~/" + Request["forum"]);
        }
    }
}