namespace Blog.Core
{
    public interface IAddBlogPostInteractor
    {
        AddBlogPostResponse AddBlogPost(AddBlogPostRequest request);
    }
}