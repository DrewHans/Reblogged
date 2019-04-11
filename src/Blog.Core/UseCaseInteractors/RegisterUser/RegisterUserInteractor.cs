using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Core
{
    public class RegisterUserInteractor : IRegisterUserInteractor
    {
        private readonly IBlogUserRepository _blogUserRepo;

        public RegisterUserInteractor(IBlogUserRepository blogUserRepo)
        {
            _blogUserRepo = blogUserRepo;
        }

        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            var response = new RegisterUserResponse();
            if (UserNameIsAvailable(request.UserName))
            {
                AddNewBlogUser(request.UserName);
                response.RegisterSuccessful = true;
            }
            return response;
        }

        private void AddNewBlogUser(string username)
        {
            var newUser = new BlogUser();
            newUser.Permissions.Add(KeyChain.BlogUser_Permission_Admin);
            newUser.TimeRegistered = DateTime.UtcNow;
            newUser.UserId = Guid.NewGuid();
            newUser.UserName = username;
            _blogUserRepo.Add(newUser);
        }

        private BlogUser GetUserByUserName(List<BlogUser> listOfBlogUsers, string username)
        {
            return listOfBlogUsers.FirstOrDefault(blogUser =>
                String.Equals(blogUser.UserName, username,
                    StringComparison.OrdinalIgnoreCase));
        }

        private bool UserNameIsAvailable(string username)
        {
            var listOfUsers = _blogUserRepo.List();
            var user = GetUserByUserName(listOfUsers, username);
            return user == null;
        }
    }
}
