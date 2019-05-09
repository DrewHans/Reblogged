using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class GetBlogUserInteractorTests
    {
        [Fact]
        public void GetBlogUser_ValidBlogPostAndUser_ReturnsExpectedResponse()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new GetBlogUserInteractor(stubBlogPostRepo, stubBlogUserRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_BlogUser = new BlogUserFactory().Create();
            stub_BlogPost.AuthorId = stub_BlogUser.UserId;
            var stub_ListOfBlogPost = new List<BlogPost> { stub_BlogPost };
            stubBlogPostRepo.StubListByAuthorId(stub_ListOfBlogPost);
            stubBlogUserRepo.StubGetById(stub_BlogUser);
            var expected = MakeResponse(stub_ListOfBlogPost, stub_BlogUser, true);
            var param_request = MakeRequest(stub_BlogUser);

            var actual = interactor.GetBlogUser(param_request);

            Assert.Equal(expected.RequestSuccessful, actual.RequestSuccessful);
            Assert.Equal(expected.ListOfPosts, actual.ListOfPosts);
            Assert.Equal(expected.User, actual.User);
        }

        [Fact]
        public void GetBlogUser_VerifyBlogPostRepository()
        {
            var mockBlogPostRepo = new MockIBlogPostRepository();
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new GetBlogUserInteractor(mockBlogPostRepo, stubBlogUserRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_BlogUser = new BlogUserFactory().Create();
            stub_BlogPost.AuthorId = stub_BlogUser.UserId;
            var stub_ListOfBlogPost = new List<BlogPost> { stub_BlogPost };
            mockBlogPostRepo.StubListByAuthorId(stub_ListOfBlogPost);
            stubBlogUserRepo.StubGetById(stub_BlogUser);
            var expected = MakeResponse(stub_ListOfBlogPost, stub_BlogUser, true);
            var param_request = MakeRequest(stub_BlogUser);

            var response = interactor.GetBlogUser(param_request);

            mockBlogPostRepo.VerifyListByAuthorId(stub_BlogUser.UserId);
        }

        [Fact]
        public void GetBlogUser_VerifyBlogUserRepository()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var mockBlogUserRepo = new MockIBlogUserRepository();
            var interactor = new GetBlogUserInteractor(stubBlogPostRepo, mockBlogUserRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_BlogUser = new BlogUserFactory().Create();
            stub_BlogPost.AuthorId = stub_BlogUser.UserId;
            var stub_ListOfBlogPost = new List<BlogPost> { stub_BlogPost };
            stubBlogPostRepo.StubListByAuthorId(stub_ListOfBlogPost);
            mockBlogUserRepo.StubGetById(stub_BlogUser);
            var expected = MakeResponse(stub_ListOfBlogPost, stub_BlogUser, true);
            var param_request = MakeRequest(stub_BlogUser);

            var response = interactor.GetBlogUser(param_request);

            mockBlogUserRepo.VerifyGetById(stub_BlogUser.UserId);
        }


        private GetBlogUserRequest MakeRequest(BlogUser stub)
        {
            return new GetBlogUserRequest
            {
                UserId = stub.UserId
            };
        }

        private GetBlogUserResponse MakeResponse(List<BlogPost> listOfPosts, BlogUser user, bool requestSuccessful)
        {
            return new GetBlogUserResponse
            {
                ListOfPosts = listOfPosts,
                User = user,
                RequestSuccessful = requestSuccessful
            };
        }
    }
}