using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class AddBlogPostInteractorTests
    {
        [Fact]
        public void AddBlogPost_ValidBlogPost_ReturnsExpectedResponse()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var interactor = new AddBlogPostInteractor(stubBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var expected = MakeResponse(stub_BlogPost, true);
            var param_request = MakeRequest(stub_BlogPost);

            var actual = interactor.AddBlogPost(param_request);

            Assert.Equal(expected.AddSuccessful, actual.AddSuccessful);
            Assert.Equal(expected.Post.AuthorId, actual.Post.AuthorId);
            Assert.Equal(expected.Post.PostBody, actual.Post.PostBody);
            Assert.Equal(expected.Post.PostTitle, actual.Post.PostTitle);
        }

        [Fact]
        public void AddBlogPost_VerifyRepository()
        {
            var mockBlogPostRepo = new MockIBlogPostRepository();
            var interactor = new AddBlogPostInteractor(mockBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var param_request = MakeRequest(stub_BlogPost);

            var response = interactor.AddBlogPost(param_request);

            mockBlogPostRepo.VerifyAdd(response.Post);
        }

        private AddBlogPostRequest MakeRequest(BlogPost stub)
        {
            return new AddBlogPostRequest
            {
                AuthorId = stub.AuthorId,
                PostBody = stub.PostBody,
                PostTitle = stub.PostTitle
            };
        }

        private AddBlogPostResponse MakeResponse(BlogPost post, bool requestSuccessful)
        {
            return new AddBlogPostResponse
            {
                Post = post,
                AddSuccessful = requestSuccessful
            };
        }
    }
}