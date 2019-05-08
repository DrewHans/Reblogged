using System;
using System.Linq;

namespace Blog.Core
{
    public class ListRecentBlogPostsInteractor : IListRecentBlogPostsInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;

        public ListRecentBlogPostsInteractor(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public ListRecentBlogPostsResponse ListRecentBlogPosts(ListRecentBlogPostsRequest request)
        {
            var response = new ListRecentBlogPostsResponse();
            try
            {
                response.ListOfRecentPosts = _blogPostRepo.List().OrderByDescending(x => x.TimeCreated).Take(5).ToList();
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
