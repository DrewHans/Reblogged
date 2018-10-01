using System;
using System.Linq;

namespace Blog.Core
{
    public class LoginUserInteractor : ILoginUserInteractor
    {
        private readonly IBlogUserRepository _blogUserRepo;

        public LoginUserInteractor(IBlogUserRepository blogUserRepo)
        {
            _blogUserRepo = blogUserRepo;
        }

        public LoginUserResponse LoginUser(LoginUserRequest request)
        {
            var response = new LoginUserResponse();
            var listOfUsers = _blogUserRepo.List();
            var user = listOfUsers.FirstOrDefault(blogUser =>
                String.Equals(blogUser.UserName, request.UserName,
                    StringComparison.OrdinalIgnoreCase));
            if (user != null)
                response.LoginSuccessful = true;
            return response;
        }
    }
}