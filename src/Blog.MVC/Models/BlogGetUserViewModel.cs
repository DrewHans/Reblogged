using System.Collections.Generic;

namespace Blog.MVC
{
    public class BlogGetUserViewModel
    {
        public List<BlogPostDTOModel> ListOfPosts = new List<BlogPostDTOModel>();
        public BlogUserDTOModel User = new BlogUserDTOModel();
    }
}
