namespace Blog.Core
{
    public interface IDeleteBlogPostInteractor
    {
        DeleteBlogPostResponse DeleteBlogPost(DeleteBlogPostRequest request);
    }
}