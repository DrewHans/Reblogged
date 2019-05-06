using System;

namespace Blog.Core
{
    public class AddBlogPostInteractor : IAddBlogPostInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;

        public AddBlogPostInteractor(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public AddBlogPostResponse AddBlogPost(AddBlogPostRequest request)
        {
            var response = new AddBlogPostResponse();
            var newPost = CreateNewPost(request);
            response.Post = newPost;
            try
            {
                _blogPostRepo.Add(newPost);
                response.AddSuccessful = true;
            }
            catch (Exception)
            {
                response.AddSuccessful = false;
            }
            return response;
        }

        private BlogPost CreateNewPost(AddBlogPostRequest request)
        {
            var newPost = new BlogPost();
            newPost.AuthorId = request.AuthorId;
            newPost.PostBody = request.PostBody;
            newPost.PostId = Guid.NewGuid();
            newPost.PostTitle = request.PostTitle;
            newPost.TimeCreated = DateTime.Now;
            newPost.TimeLastModified = newPost.TimeCreated;
            return newPost;
        }
    }
}
