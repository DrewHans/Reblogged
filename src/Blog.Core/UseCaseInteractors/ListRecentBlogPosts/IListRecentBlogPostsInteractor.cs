namespace Blog.Core
{
    public interface IListRecentBlogPostsInteractor
    {
        ListRecentBlogPostsResponse ListRecentBlogPosts(ListRecentBlogPostsRequest request);
    }
}