using System;
using System.Linq;

namespace Blog.Core
{
    public class ListBlogPostsByAuthorInteractor : IListBlogPostsByAuthorInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;

        public ListBlogPostsByAuthorInteractor(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public ListBlogPostsByAuthorResponse ListBlogPostsByAuthor(ListBlogPostsByAuthorRequest request)
        {
            var response = new ListBlogPostsByAuthorResponse();
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
