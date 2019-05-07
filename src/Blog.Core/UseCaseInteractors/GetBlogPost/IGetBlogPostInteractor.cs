namespace Blog.Core
{
    public interface IGetBlogPostInteractor
    {
        GetBlogPostResponse GetBlogPost(GetBlogPostRequest request);
    }
}