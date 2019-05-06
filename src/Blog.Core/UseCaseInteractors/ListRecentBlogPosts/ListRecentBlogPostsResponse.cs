using System.Collections.Generic;

namespace Blog.Core
{
    public class ListRecentBlogPostsResponse
    {
    	public List<BlogPost> ListOfRecentPosts;
        public bool RequestSuccessful = false;
    }
}