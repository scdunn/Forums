using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zobuno.forums
{
    public partial class ViewTopics : System.Web.UI.Page
    {
        public int pageSize = 10;
        public Forum Forum { get; set; }
        ForumsDC data = new ForumsDC();


        public string DateToText(string dateValue)
        {
            return helper.DateToText(dateValue);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Forum = data.Forums.SingleOrDefault(m => m.Url == Request.QueryString["forum"]);

            topicList.ItemCommand += new RepeaterCommandEventHandler(topicList_ItemCommand);

            this.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            if (User.Identity.IsAuthenticated)
            {
                btnAddTopic.Visible = true;
                btnAddTopic.NavigateUrl = "~/addtopic/" + Forum.Url;
            }

            if(!IsPostBack)
                refreshTopics();


        }

        void refreshTopics()
        {
            int currentPage = 1;

            if (!string.IsNullOrEmpty(Request["p"]))
                currentPage = Int32.Parse(Request["p"]);



            DataBind();

            var ds = (from ForumTopic topic in data.ForumTopics
                      where topic.Forum.ID == Forum.ID
                      orderby topic.LastPostDate descending
                      select topic);

            int totalTopics = ds.Count();

            topicList.DataSource = ds.Skip((currentPage - 1) * pageSize).Take(pageSize);
            topicList.DataBind();

            int numPages = (totalTopics / pageSize) + (totalTopics % pageSize > 0 ? 1 : 0);

            if (numPages > 1)
            {
                for (int iPage = 1; iPage <= numPages; iPage++)
                {
                    if (currentPage == iPage)
                        paging.Controls.Add(new LiteralControl("<a href=\"?p=" + iPage + "\" class=\"current\">" + iPage.ToString() + "</a>"));
                    else
                        paging.Controls.Add(new LiteralControl("<a href=\"?p=" + iPage + "\">" + iPage.ToString() + "</a>"));
                }
            }


        }

        void topicList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                data.ForumTopics.DeleteOnSubmit(data.ForumTopics.SingleOrDefault(m => m.ID.ToString() == e.CommandArgument.ToString()));
                data.SubmitChanges();
                refreshTopics();
            }
        }
    }
}