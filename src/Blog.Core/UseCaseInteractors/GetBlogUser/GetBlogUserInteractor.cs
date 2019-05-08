using System;
using System.Linq;

namespace Blog.Core
{
    public class GetBlogUserInteractor : IGetBlogUserInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;
        private readonly IBlogUserRepository _blogUserRepo;

        public GetBlogUserInteractor(IBlogPostRepository blogPostRepo, IBlogUserRepository blogUserRepo)
        {
            _blogPostRepo = blogPostRepo;
            _blogUserRepo = blogUserRepo;
        }

        public GetBlogUserResponse GetBlogUser(GetBlogUserRequest request)
        {
            var response = new GetBlogUserResponse();
            try
            {
                response.User = _blogUserRepo.GetById(request.UserId);
                response.User.Permissions = null;
                response.ListOfPosts = _blogPostRepo.ListByAuthorId(request.UserId);
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
