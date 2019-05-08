using System;
using System.Linq;

namespace Blog.Core
{
    public class GetBlogPostInteractor : IGetBlogPostInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;
        private readonly IBlogUserRepository _blogUserRepo;

        public GetBlogPostInteractor(IBlogPostRepository blogPostRepo, IBlogUserRepository blogUserRepo)
        {
            _blogPostRepo = blogPostRepo;
            _blogUserRepo = blogUserRepo;
        }

        public GetBlogPostResponse GetBlogPost(GetBlogPostRequest request)
        {
            var response = new GetBlogPostResponse();
            try
            {
                response.Post = _blogPostRepo.GetById(request.PostId);
                response.User = _blogUserRepo.GetById(response.Post.AuthorId);
                response.User.Permissions = null;
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
