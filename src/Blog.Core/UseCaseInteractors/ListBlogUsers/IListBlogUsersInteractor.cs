namespace Blog.Core
{
    public interface IListBlogUsersInteractor
    {
        ListBlogUsersResponse ListBlogUsers(ListBlogUsersRequest request);
    }
}