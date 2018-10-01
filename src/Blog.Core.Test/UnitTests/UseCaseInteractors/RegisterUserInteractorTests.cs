using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class RegisterUserInteractorTests
    {
        [Fact]
        public void RegisterUser_UserNameIsAvailable_ReturnsExpectedRegisterUserResponse()
        {
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new RegisterUserInteractor(stubBlogUserRepo);
            stubBlogUserRepo.StubList(new List<BlogUser>());
            var expected = new RegisterUserResponse { RegisterSuccessful = true };
            var param_request = new RegisterUserRequest { UserName = "Poptart" };

            var actual = interactor.RegisterUser(param_request);

            Assert.Equal(expected.RegisterSuccessful, actual.RegisterSuccessful);
        }

        [Fact]
        public void RegisterUser_UserNameIsAvailable_VerifyRepository()
        {
            var mockBlogUserRepo = new MockIBlogUserRepository();
            var interactor = new RegisterUserInteractor(mockBlogUserRepo);
            mockBlogUserRepo.StubList(new List<BlogUser>());
            var param_request = new RegisterUserRequest { UserName = "Poptart" };

            interactor.RegisterUser(param_request);

            mockBlogUserRepo.VerifyList();
            mockBlogUserRepo.VerifyAddCalled(1);
        }

        [Fact]
        public void RegisterUser_UserNameIsNotAvailable_ReturnsExpectedRegisterUserResponse()
        {
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new RegisterUserInteractor(stubBlogUserRepo);
            var stub_blogUser = new BlogUserFactory().Create();
            var stub_list = new List<BlogUser> { stub_blogUser };
            stubBlogUserRepo.StubList(stub_list);
            var expected = new RegisterUserResponse { RegisterSuccessful = false };
            var param_request = new RegisterUserRequest { UserName = stub_blogUser.UserName };

            var actual = interactor.RegisterUser(param_request);

            Assert.Equal(expected.RegisterSuccessful, actual.RegisterSuccessful);
        }

        [Fact]
        public void RegisterUser_UserNameIsNotAvailable_VerifyRepository()
        {
            var mockBlogUserRepo = new MockIBlogUserRepository();
            var interactor = new RegisterUserInteractor(mockBlogUserRepo);
            var stub_blogUser = new BlogUserFactory().Create();
            mockBlogUserRepo.StubList(new List<BlogUser> { stub_blogUser });
            var param_request = new RegisterUserRequest { UserName = stub_blogUser.UserName };

            var actual = interactor.RegisterUser(param_request);

            mockBlogUserRepo.VerifyList();
            mockBlogUserRepo.VerifyAddNeverCalled();
        }
    }
}