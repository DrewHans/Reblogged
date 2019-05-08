using System;

namespace Blog.Core
{
    public class AddBlogPostRequest
    {
        public Guid AuthorId;
        public string PostBody;
        public string PostTitle;
    }
}