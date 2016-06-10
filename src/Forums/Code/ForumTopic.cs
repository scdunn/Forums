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
    [Table(Name = "dbo.ForumTopics")]
    public partial class ForumTopic
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(DbType = "int")]
        public int UserID { get; set; }

        [Column(DbType = "int")]
        public int ForumID { get; set; }

        [Column(DbType = "VarChar(50)")]
        public string Title { get; set; }

        [Column(DbType = "varchar(max)")]
        public string Description { get; set; }

        [Column(DbType = "datetime")]
        public DateTime DateCreated { get; set; }
        
        [Column(DbType = "datetime")]
        public DateTime DateUpdated { get; set; }

        private EntityRef<User> _User;
        [Association(Storage = "_User", ThisKey = "UserID")]
        public User User
        {
            get { return this._User.Entity; }
            set { this._User.Entity = value; }
        }

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

        private EntityRef<Forum> _Forum;
        [Association(Storage = "_Forum", ThisKey = "ForumID")]
        public Forum Forum
        {
            get { return this._Forum.Entity; }
            set { this._Forum.Entity = value; }
        }


        public ForumTopic()
        {
            
            ForumPosts = new EntitySet<ForumPost>();
        }

        public ForumPost LastPost { get { if (ForumPosts.Count == 0) return new ForumPost() { User=this.User, DateCreated=this.DateCreated }; return ForumPosts.Last(); } }

        private EntitySet<ForumPost> _ForumPosts;
        [Association(Storage = "_ForumPosts",ThisKey="ID", OtherKey = "TopicID")]
        public EntitySet<ForumPost> ForumPosts
        {
        set{_ForumPosts = value;}
        get{return _ForumPosts;}
        }
    
    }

}

