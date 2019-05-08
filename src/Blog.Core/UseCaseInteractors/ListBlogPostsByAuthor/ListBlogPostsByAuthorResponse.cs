using System.Collections.Generic;

namespace Blog.Core
{
    public class ListBlogPostsByAuthorResponse
    {
    	public List<BlogPost> ListOfPosts;
        public bool RequestSuccessful = false;
    }
}