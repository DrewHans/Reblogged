using System;
using System.Linq;

namespace Blog.Core
{
    public class ListBlogPostsInteractor : IListBlogPostsInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;

        public ListBlogPostsInteractor(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public ListBlogPostsResponse ListBlogPosts(ListBlogPostsRequest request)
        {
            var response = new ListBlogPostsResponse();
            try
            {
                response.ListOfPosts = _blogPostRepo.List().OrderBy(x => x.TimeCreated).ToList();
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
