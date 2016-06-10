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
    [Table(Name = "dbo.Forums")]
    public partial class Forum
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(DbType = "VarChar(50)")]
        public string Title { get; set; }

        [Column(DbType = "varchar(max)")]
        public string Description { get; set; }

        private EntitySet<ForumTopic> _ForumTopics;
        [Association(Storage = "_ForumTopics", ThisKey = "ID", OtherKey = "ForumID")]
        public EntitySet<ForumTopic> ForumTopics
        {
            set { _ForumTopics = value; }
            get { return _ForumTopics; }    
        }

        public ForumPost LastPost { get {
            if (ForumPosts.Count > 0)
                return ForumPosts.Last();
            else
                return null;
        }
        }

        private EntitySet<ForumPost> _ForumPosts;
        [Association(Storage = "_ForumPosts", ThisKey = "ID", OtherKey = "ForumID")]
        public EntitySet<ForumPost> ForumPosts
        {
            set { _ForumPosts = value; }
            get { return _ForumPosts; }
        }

        [Column(DbType = "VarChar(50)")]
        public string Url { get; set; }


        [Column(DbType = "Int")]
        public int LastPostUserID { get; set; }

        private EntityRef<User> _LastPostUser;
        [Association(Storage = "_LastPostUser", ThisKey = "LastPostUserID")]
        public User LastPostUser
        {
            get { return this._LastPostUser.Entity; }
            set { this._LastPostUser.Entity = value; }
        }

        [Column(DbType = "datetime")]
        public DateTime LastPostDate { get; set; }

        [Column(DbType = "Int")]
        public int PostCount { get; set; }

        [Column(DbType = "Int")]
        public int TopicCount { get; set; }

    }
}
