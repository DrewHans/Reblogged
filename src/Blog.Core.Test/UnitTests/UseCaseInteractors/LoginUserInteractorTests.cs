using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class LoginUserInteractorTests
    {
        [Fact]
        public void LoginUser_UserNameExists_ReturnsExpectedLoginUserResponse()
        {
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new LoginUserInteractor(stubBlogUserRepo);
            var stub_blogUser = new BlogUserFactory().Create();
            var stub_list = new List<BlogUser> { stub_blogUser };
            stubBlogUserRepo.StubList(stub_list);
            var expected = MakeResponse(stub_blogUser, true);
            var param_request = MakeRequest(stub_blogUser.UserName);

            var actual = interactor.LoginUser(param_request);

            Assert.Equal(expected.SystemLoginSuccessful, actual.SystemLoginSuccessful);
            Assert.Equal(expected.User, actual.User);
        }

        [Fact]
        public void LoginUser_UserNameDoesNotExists_ReturnsExpectedLoginUserResponse()
        {
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new LoginUserInteractor(stubBlogUserRepo);
            stubBlogUserRepo.StubList(new List<BlogUser>());
            var expected = MakeResponse(null, false);
            var param_request = MakeRequest("Poptart");

            var actual = interactor.LoginUser(param_request);

            Assert.Equal(expected.SystemLoginSuccessful, actual.SystemLoginSuccessful);
        }

        [Fact]
        public void LoginUser_VerifyRepository()
        {
            var mockBlogUserRepo = new MockIBlogUserRepository();
            var interactor = new LoginUserInteractor(mockBlogUserRepo);
            var param_request = MakeRequest("Poptart");
            mockBlogUserRepo.StubList(new List<BlogUser>());

            interactor.LoginUser(param_request);

            mockBlogUserRepo.VerifyList();
        }

        private LoginUserRequest MakeRequest(string username)
        {
            return new LoginUserRequest
            {
                UserName = username
            };
        }

        private LoginUserResponse MakeResponse(BlogUser blogUser, bool loginSuccessful)
        {
            return new LoginUserResponse
            {
                User = blogUser,
                SystemLoginSuccessful = loginSuccessful
            };
        }
    }
}