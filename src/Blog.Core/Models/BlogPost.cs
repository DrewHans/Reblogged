using System;
using System.Data;

namespace Blog.Core
{
    [SqlTable(TableName = "blogpost")]
    public class BlogPost
    {
        [SqlColumn(ColumnName = "authorid", SqlDbType = SqlDbType.NChar)]
        public Guid AuthorId { get; set; }

        [SqlColumn(ColumnName = "body", SqlDbType = SqlDbType.NChar)]
        public string PostBody { get; set; }

        [SqlColumn(ColumnName = "id", SqlDbType = SqlDbType.NChar)]
        public Guid PostId { get; set; }

        [SqlColumn(ColumnName = "title", SqlDbType = SqlDbType.NChar)]
        public string PostTitle { get; set; }

        [SqlColumn(ColumnName = "timecreated", SqlDbType = SqlDbType.DateTime)]
        public DateTime TimeCreated { get; set; }

        [SqlColumn(ColumnName = "timemodified", SqlDbType = SqlDbType.DateTime)]
        public DateTime TimeLastModified { get; set; }
    }
}