using System;
using System.Data;

namespace Blog.Core
{
    [SqlTable(TableName = KeyChain.SqlServerDataAccess_BlogPost_TableName)]
    public class BlogPost
    {
        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogPost_ColumnName_AuthorId,
            SqlDbType = SqlDbType.NChar)]
        public Guid AuthorId { get; set; }

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogPost_ColumnName_PostBody,
            SqlDbType = SqlDbType.NChar)]
        public string PostBody { get; set; }

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogPost_ColumnName_PostId,
            SqlDbType = SqlDbType.NChar)]
        public Guid PostId { get; set; }

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogPost_ColumnName_PostTitle,
            SqlDbType = SqlDbType.NChar)]
        public string PostTitle { get; set; }

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogPost_ColumnName_TimeCreated,
            SqlDbType = SqlDbType.DateTime)]
        public DateTime TimeCreated { get; set; }

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogPost_ColumnName_TimeLastModified,
            SqlDbType = SqlDbType.DateTime)]
        public DateTime TimeLastModified { get; set; }
    }
}