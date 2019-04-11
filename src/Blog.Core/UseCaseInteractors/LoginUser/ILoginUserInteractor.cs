namespace Blog.Core
{
    public interface ILoginUserInteractor
    {
        LoginUserResponse LoginUser(LoginUserRequest request);
    }
}