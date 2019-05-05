using System;

namespace Blog.Core
{
    public class DeleteBlogPostInteractor : IDeleteBlogPostInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;

        public DeleteBlogPostInteractor(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public DeleteBlogPostResponse DeleteBlogPost(DeleteBlogPostRequest request)
        {
            var response = new DeleteBlogPostResponse();
            var postId = Guid.Parse(request.PostId);
            try
            {
                var post = _blogPostRepo.GetById(postId);
                _blogPostRepo.Delete(post);
                response.DeleteSuccessful = true;
            }
            catch (Exception)
            {
                response.DeleteSuccessful = false;
            }
            return response;
        }
    }
}
