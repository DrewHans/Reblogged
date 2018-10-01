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
            var expected = new LoginUserResponse { LoginSuccessful = true };
            var param_request = new LoginUserRequest { UserName = stub_blogUser.UserName };

            var actual = interactor.LoginUser(param_request);

            Assert.Equal(expected.LoginSuccessful, actual.LoginSuccessful);
        }

        [Fact]
        public void LoginUser_UserNameDoesNotExists_ReturnsExpectedLoginUserResponse()
        {
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new LoginUserInteractor(stubBlogUserRepo);
            stubBlogUserRepo.StubList(new List<BlogUser>());
            var expected = new LoginUserResponse { LoginSuccessful = false };
            var param_request = new LoginUserRequest { UserName = "Poptart" };

            var actual = interactor.LoginUser(param_request);

            Assert.Equal(expected.LoginSuccessful, actual.LoginSuccessful);
        }

        [Fact]
        public void LoginUser_VerifyRepository()
        {
            var mockBlogUserRepo = new MockIBlogUserRepository();
            var interactor = new LoginUserInteractor(mockBlogUserRepo);
            var param_request = new LoginUserRequest { UserName = "Poptart" };
            mockBlogUserRepo.StubList(new List<BlogUser>());

            interactor.LoginUser(param_request);

            mockBlogUserRepo.VerifyList();
        }
    }
}