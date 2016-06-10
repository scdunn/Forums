using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System;
using System.Data.SqlClient;

namespace zobuno.forums
{



    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name = "forums")]
    public partial class ForumsDC : System.Data.Linq.DataContext
    {

        #region Data Context Base Functions
        
            private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

            public ForumsDC() : base(global::zobuno.forums.Properties.Settings.Default.forums, mappingSource) { }

            public ForumsDC(string connection) : base(connection, mappingSource){}

            public ForumsDC(System.Data.IDbConnection connection) : base(connection, mappingSource){}

            public ForumsDC(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :base(connection, mappingSource){}

            public ForumsDC(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : base(connection, mappingSource) { }

        #endregion

        #region Entity Table Functions
        //account
        public System.Data.Linq.Table<Forum> Forums
        {
            get
            {
                return this.GetTable<Forum>();
            }
        }
        public System.Data.Linq.Table<ForumTopic> ForumTopics
        {
            get
            {
                return this.GetTable<ForumTopic>();
            }
        }
        public System.Data.Linq.Table<ForumPost> ForumPosts
        {
            get
            {
                return this.GetTable<ForumPost>();
            }
        }
        public System.Data.Linq.Table<User> Users
        {
            get
            {
                return this.GetTable<User>();
            }
        }

        #endregion

     
    }




}
