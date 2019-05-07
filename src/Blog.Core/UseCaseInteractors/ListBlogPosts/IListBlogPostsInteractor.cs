namespace Blog.Core
{
    public interface IListBlogPostsInteractor
    {
        ListBlogPostsResponse ListBlogPosts(ListBlogPostsRequest request);
    }
}