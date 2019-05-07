using System;
using System.Linq;

namespace Blog.Core
{
    public class ListBlogUsersInteractor : IListBlogUsersInteractor
    {
        private readonly IBlogUserRepository _blogUserRepo;

        public ListBlogUsersInteractor(IBlogUserRepository blogUserRepo)
        {
            _blogUserRepo = blogUserRepo;
        }

        public ListBlogUsersResponse ListBlogUsers(ListBlogUsersRequest request)
        {
            var response = new ListBlogUsersResponse();
            try
            {
                response.ListOfUsers = _blogUserRepo.List().OrderBy(x => x.TimeRegistered).ToList();
                response.RequestSuccessful = true;
            }
            catch (Exception)
            {
                response.RequestSuccessful = false;
            }
            return response;
        }
    }
}
