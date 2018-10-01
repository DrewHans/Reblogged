namespace Blog.Core
{
    public interface IRegisterUserInteractor
    {
        RegisterUserResponse RegisterUser(RegisterUserRequest request);
    }
}