using System;
using System.Collections.Generic;
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
            if (UserNameExists(request.UserName))
                response.LoginSuccessful = true;
            return response;
        }

        private BlogUser GetUserByUserName(List<BlogUser> listOfBlogUsers, string username)
        {
            return listOfBlogUsers.FirstOrDefault(blogUser =>
                String.Equals(blogUser.UserName, username,
                    StringComparison.OrdinalIgnoreCase));
        }

        private bool UserNameExists(string username)
        {
            var listOfUsers = _blogUserRepo.List();
            var user = GetUserByUserName(listOfUsers, username);
            return user != null;
        }
    }
}