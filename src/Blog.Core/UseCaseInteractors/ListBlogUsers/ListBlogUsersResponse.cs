using System.Collections.Generic;

namespace Blog.Core
{
    public class ListBlogUsersResponse
    {
    	public List<BlogUser> ListOfUsers;
        public bool RequestSuccessful = false;
    }
}