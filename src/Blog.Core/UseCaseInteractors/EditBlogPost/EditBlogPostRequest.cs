using System;
namespace Blog.Core
{
    public class EditBlogPostRequest
    {
        public string PostBody;
        public Guid PostId;
        public string PostTitle;
    }
}