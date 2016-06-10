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
    [Table(Name = "dbo.ForumPosts")]
    public partial class ForumPost
    {
        [Column(AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column(DbType = "int")]
        public int UserID { get; set; }

        [Column(DbType = "int")]
        public int TopicID { get; set; }

        [Column(DbType = "varchar(max)")]
        public string Description { get; set; }

        [Column(DbType = "datetime")]
        public DateTime DateCreated { get; set; }

        [Column(DbType = "int")]
        public int ForumID { get; set; }

        private EntityRef<ForumTopic> _ForumTopic;
        [Association(Storage = "_ForumTopic", ThisKey = "ForumID")]
        public ForumTopic ForumTopic
        {
            get { return this._ForumTopic.Entity; }
            set { this._ForumTopic.Entity = value; }
        }


        private EntityRef<User> _User;
        [Association(Storage = "_User", ThisKey = "UserID")]
        public User User
        {
            get { return this._User.Entity; }
            set { this._User.Entity = value; }
        }


    }
}
