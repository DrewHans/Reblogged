using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class GetBlogPostInteractorTests
    {
        [Fact]
        public void GetBlogPost_ValidBlogPostAndUser_ReturnsExpectedResponse()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new GetBlogPostInteractor(stubBlogPostRepo, stubBlogUserRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_BlogUser = new BlogUserFactory().Create();
            stub_BlogPost.AuthorId = stub_BlogUser.UserId;
            stubBlogPostRepo.StubGetById(stub_BlogPost);
            stubBlogUserRepo.StubGetById(stub_BlogUser);
            var expected = MakeResponse(stub_BlogPost, stub_BlogUser, true);
            var param_request = MakeRequest(stub_BlogPost);

            var actual = interactor.GetBlogPost(param_request);

            Assert.Equal(expected.RequestSuccessful, actual.RequestSuccessful);
            Assert.Equal(expected.Post, actual.Post);
            Assert.Equal(expected.User, actual.User);
        }

        [Fact]
        public void GetBlogPost_VerifyBlogPostRepository()
        {
            var mockBlogPostRepo = new MockIBlogPostRepository();
            var stubBlogUserRepo = new StubIBlogUserRepository();
            var interactor = new GetBlogPostInteractor(mockBlogPostRepo, stubBlogUserRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_BlogUser = new BlogUserFactory().Create();
            stub_BlogPost.AuthorId = stub_BlogUser.UserId;
            mockBlogPostRepo.StubGetById(stub_BlogPost);
            stubBlogUserRepo.StubGetById(stub_BlogUser);
            var expected = MakeResponse(stub_BlogPost, stub_BlogUser, true);
            var param_request = MakeRequest(stub_BlogPost);

            var response = interactor.GetBlogPost(param_request);

            mockBlogPostRepo.VerifyGetById(stub_BlogPost.PostId);
        }

        [Fact]
        public void GetBlogPost_VerifyBlogUserRepository()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var mockBlogUserRepo = new MockIBlogUserRepository();
            var interactor = new GetBlogPostInteractor(stubBlogPostRepo, mockBlogUserRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_BlogUser = new BlogUserFactory().Create();
            stub_BlogPost.AuthorId = stub_BlogUser.UserId;
            stubBlogPostRepo.StubGetById(stub_BlogPost);
            mockBlogUserRepo.StubGetById(stub_BlogUser);
            var expected = MakeResponse(stub_BlogPost, stub_BlogUser, true);
            var param_request = MakeRequest(stub_BlogPost);

            var response = interactor.GetBlogPost(param_request);

            mockBlogUserRepo.VerifyGetById(stub_BlogUser.UserId);
        }


        private GetBlogPostRequest MakeRequest(BlogPost stub)
        {
            return new GetBlogPostRequest
            {
                PostId = stub.PostId
            };
        }

        private GetBlogPostResponse MakeResponse(BlogPost post, BlogUser user, bool requestSuccessful)
        {
            return new GetBlogPostResponse
            {
                Post = post,
                User = user,
                RequestSuccessful = requestSuccessful
            };
        }
    }
}