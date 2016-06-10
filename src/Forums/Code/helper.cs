using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace zobuno.forums
{
    public class helper
    {
        public static string CleanHtml(string html)
        {
            string val = Regex.Replace(html, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            val = HttpUtility.HtmlEncode(val);
            return val;

        }

        //return current logged in user
        public static User CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["zobuno-user"] != null)
                    return (User)HttpContext.Current.Session["zobuno-user"];
                else
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        ForumsDC data = new ForumsDC();
                        User newUser = data.Users.SingleOrDefault(m => m.ID.ToString() == HttpContext.Current.User.Identity.Name);
                        //User newUser = data.Users.SingleOrDefault(m => m.ID.ToString() == "22");
                        HttpContext.Current.Session["zobuno-user"] = newUser;
                        return newUser;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            set
            { }
        }

        public static string DateToText(string dateValue)
        {
            DateTime date = DateTime.Parse(dateValue);
            string dateText = "";
            DateTime today = DateTime.Today;


            if (date < today.AddMonths(-1))
                dateText = date.ToString("MMMM yyyy");
            else
            {
                TimeSpan fromToday = DateTime.Now.Subtract(date);
                if (fromToday.Days >= 28)
                    dateText = "4 weeks ago";
                else if (fromToday.Days >= 21)
                    dateText = "3 weeks ago";
                else if (fromToday.Days >= 14)
                    dateText = "2 weeks ago";
                else if (fromToday.Days >= 7)
                    dateText = "1 week ago";
                else if (fromToday.Days > 1)
                    dateText = fromToday.Days + " days ago";
                else if (fromToday.Days == 1)
                    dateText = "Yesterday";
                else
                    dateText = "Today at " + date.ToString("hh:mm tt");
            }

            return dateText;
        }
    }
}