namespace Blog.Core
{
    public interface IEditBlogPostInteractor
    {
        EditBlogPostResponse EditBlogPost(EditBlogPostRequest request);
    }
}