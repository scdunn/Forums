using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System;
using System.Xml.Linq;
using System.Web;

namespace zobuno.forums
{
    /// <summary>
    /// Represents a single account user.
    /// </summary>
    [Table(Name = "dbo.Users")]
    public class User
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(DbType = "VarChar(50)")]
        public string EmailAddress { get; set; }

        [Column(DbType = "VarChar(50)")]
        public string FirstName { get; set; }

        [Column(DbType = "VarChar(50)")]
        public string LastName { get; set; }

        [Column(DbType = "VarChar(50)")]
        public string Nickname { get; set; }

        [Column(DbType = "VarChar(255)")]
        public string Password { get; set; }

        [Column(DbType = "Int")]
        public int AccountID { get; set; }

        [Column(DbType = "Bit")]
        public bool IsAdmin { get; set; }


        public int PostCount
        {get{
            return ForumPosts.Count;
        }
        }

        private EntitySet<ForumPost> _ForumPosts;
        [Association(Storage = "_ForumPosts", ThisKey = "ID", OtherKey = "UserID")]
        public EntitySet<ForumPost> ForumPosts
        {
            set { _ForumPosts = value; }
            get { return _ForumPosts; }
        }
    }
}