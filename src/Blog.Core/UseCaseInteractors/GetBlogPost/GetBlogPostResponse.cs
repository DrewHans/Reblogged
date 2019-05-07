using System.Collections.Generic;

namespace Blog.Core
{
    public class GetBlogPostResponse
    {
    	public BlogPost Post;
    	public BlogUser User;
        public bool RequestSuccessful = false;
    }
}