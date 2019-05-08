using System.Collections.Generic;

namespace Blog.Core
{
    public class GetBlogUserResponse
    {
        public List<BlogPost> ListOfPosts = new List<BlogPost>();
    	public BlogUser User;
        public bool RequestSuccessful = false;
    }
}