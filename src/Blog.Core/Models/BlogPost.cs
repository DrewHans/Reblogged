using System;
using System.Data;

namespace Blog.Core
{
    [SqlTable(Name = "blogpost")]
    public class BlogPost
    {
        [SqlColumn(Name = "authorid", Type = SqlDbType.NChar)]
        public Guid AuthorId { get; set; }

        [SqlColumn(Name = "body", Type = SqlDbType.NChar)]
        public string PostBody { get; set; }

        [SqlColumn(Name = "id", Type = SqlDbType.NChar)]
        public Guid PostId { get; set; }

        [SqlColumn(Name = "title", Type = SqlDbType.NChar)]
        public string PostTitle { get; set; }

        [SqlColumn(Name = "timecreated", Type = SqlDbType.DateTime)]
        public DateTime TimeCreated { get; set; }

        [SqlColumn(Name = "timemodified", Type = SqlDbType.DateTime)]
        public DateTime TimeLastModified { get; set; }
    }
}