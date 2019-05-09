using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class ListBlogUsersInteractorTests
    {
        [Fact]
        public void ListBlogUsers_ReturnsExpectedResponse()
        {
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new ListBlogUsersInteractor(stubBlogUserRepo);
            var stub_BlogUser = new BlogUserFactory().Create();
            var stub_listOfUsers = new List<BlogUser> { stub_BlogUser };
            stubBlogUserRepo.StubList(stub_listOfUsers);
            var expected = MakeResponse(stub_listOfUsers, true);
            var param_request = MakeRequest(stub_BlogUser);

            var actual = interactor.ListBlogUsers(param_request);

            Assert.Equal(expected.RequestSuccessful, actual.RequestSuccessful);
            Assert.Equal(expected.ListOfUsers, actual.ListOfUsers);
        }

        [Fact]
        public void ListBlogUsers_VerifyBlogUserRepository()
        {
            var mockBlogUserRepo = new MockIBlogUserRepository();
            var interactor = new ListBlogUsersInteractor(mockBlogUserRepo);
            var stub_BlogUser = new BlogUserFactory().Create();
            var stub_listOfUsers = new List<BlogUser> { stub_BlogUser };
            mockBlogUserRepo.StubList(stub_listOfUsers);
            var expected = MakeResponse(stub_listOfUsers, true);
            var param_request = MakeRequest(stub_BlogUser);

            var response = interactor.ListBlogUsers(param_request);

            mockBlogUserRepo.VerifyList();
        }


        private ListBlogUsersRequest MakeRequest(BlogUser stub)
        {
            return new ListBlogUsersRequest();
        }

        private ListBlogUsersResponse MakeResponse(List<BlogUser> listOfUsers, bool requestSuccessful)
        {
            return new ListBlogUsersResponse
            {
                ListOfUsers = listOfUsers,
                RequestSuccessful = requestSuccessful
            };
        }
    }
}