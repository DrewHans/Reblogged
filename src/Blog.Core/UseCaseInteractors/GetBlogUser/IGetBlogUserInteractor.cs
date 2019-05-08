namespace Blog.Core
{
    public interface IGetBlogUserInteractor
    {
        GetBlogUserResponse GetBlogUser(GetBlogUserRequest request);
    }
}