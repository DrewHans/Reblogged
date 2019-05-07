using System.Collections.Generic;

namespace Blog.Core
{
    public class ListBlogPostsResponse
    {
    	public List<BlogPost> ListOfPosts;
        public bool RequestSuccessful = false;
    }
}