using System;

namespace Blog.Core
{
    public class EditBlogPostInteractor : IEditBlogPostInteractor
    {
        private readonly IBlogPostRepository _blogPostRepo;

        public EditBlogPostInteractor(IBlogPostRepository blogPostRepo)
        {
            _blogPostRepo = blogPostRepo;
        }

        public EditBlogPostResponse EditBlogPost(EditBlogPostRequest request)
        {
            var response = new EditBlogPostResponse();
            var postId = Guid.Parse(request.PostId);
            var oldPost = _blogPostRepo.GetById(postId);
            var updatedPost = UpdatePost(oldPost, request);
            response.Post = updatedPost;
            try
            {
                _blogPostRepo.Edit(updatedPost);
                response.EditSuccessful = true;
            }
            catch (Exception)
            {
                response.EditSuccessful = false;
            }
            return response;
        }

        private BlogPost UpdatePost(BlogPost oldPost, EditBlogPostRequest request)
        {
            oldPost.PostBody = request.PostBody;
            oldPost.PostTitle = request.PostTitle;
            oldPost.TimeLastModified = DateTime.Now;
            return oldPost;
        }
    }
}
