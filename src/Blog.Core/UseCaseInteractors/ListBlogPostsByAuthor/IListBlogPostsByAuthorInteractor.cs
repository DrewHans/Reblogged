namespace Blog.Core
{
    public interface IListBlogPostsByAuthorInteractor
    {
        ListBlogPostsByAuthorResponse ListBlogPostsByAuthor(ListBlogPostsByAuthorRequest request);
    }
}