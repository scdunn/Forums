using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using zobuno.forums;

namespace Forums
{
    public partial class _Default : System.Web.UI.Page
    {

        public string DateToText(string dateValue)
        {
            return helper.DateToText(dateValue);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ForumsDC data = new ForumsDC();

            forumList.DataSource = data.Forums;
            forumList.DataBind();

        }
    }
}
