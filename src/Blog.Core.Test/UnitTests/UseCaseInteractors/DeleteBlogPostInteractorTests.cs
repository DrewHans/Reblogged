using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class DeleteBlogPostInteractorTests
    {
        [Fact]
        public void DeleteBlogPost_ValidBlogPost_ReturnsExpectedResponse()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var interactor = new DeleteBlogPostInteractor(stubBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            stubBlogPostRepo.StubGetById(stub_BlogPost);
            var expected = MakeResponse(true);
            var param_request = MakeRequest(stub_BlogPost);

            var actual = interactor.DeleteBlogPost(param_request);

            Assert.Equal(expected.DeleteSuccessful, actual.DeleteSuccessful);
        }

        [Fact]
        public void DeleteBlogPost_VerifyRepository()
        {
            var mockBlogPostRepo = new MockIBlogPostRepository();
            var interactor = new DeleteBlogPostInteractor(mockBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            mockBlogPostRepo.StubGetById(stub_BlogPost);
            var param_request = MakeRequest(stub_BlogPost);

            var response = interactor.DeleteBlogPost(param_request);

            mockBlogPostRepo.VerifyGetById(stub_BlogPost.PostId);
            mockBlogPostRepo.VerifyDelete(stub_BlogPost);
        }

        private DeleteBlogPostRequest MakeRequest(BlogPost stub)
        {
            return new DeleteBlogPostRequest
            {
                PostId = stub.PostId
            };
        }

        private DeleteBlogPostResponse MakeResponse(bool requestSuccessful)
        {
            return new DeleteBlogPostResponse
            {
                DeleteSuccessful = requestSuccessful
            };
        }
    }
}