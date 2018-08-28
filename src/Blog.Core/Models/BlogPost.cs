using System;

namespace Blog.Core
{
    public class BlogPost
    {
        public Guid AuthorId { get; set; }
        public string PostBody { get; set; }
        public Guid PostId { get; set; }
        public string PostTitle { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
    }
}