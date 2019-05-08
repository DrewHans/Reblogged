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
            var bloguser = GetUserByUserName(request.UserName);
            if (UserExists(bloguser))
            {
                response.User = bloguser;
                response.SystemLoginSuccessful = true;
                // our login protocol just checks to see if they have registered
                // password management & authentication is beyond the scope of this project
            }
            return response;
        }

        private BlogUser GetUserByUserName(string username)
        {
            return _blogUserRepo.List().FirstOrDefault(blogUser =>
                String.Equals(blogUser.UserName, username,
                    StringComparison.OrdinalIgnoreCase));
        }

        private bool UserExists(BlogUser bloguser)
        {
            return bloguser != null;
        }
    }
}