using System;
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
            var listOfUsers = _blogUserRepo.List();
            var user = listOfUsers.FirstOrDefault(blogUser =>
                String.Equals(blogUser.UserName, request.UserName,
                    StringComparison.OrdinalIgnoreCase));
            if (user == null)
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
    }
}