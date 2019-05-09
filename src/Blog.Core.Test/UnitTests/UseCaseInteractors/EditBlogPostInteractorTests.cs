using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class EditBlogPostInteractorTests
    {
        [Fact]
        public void EditBlogPost_ValidBlogPost_ReturnsExpectedResponse()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var interactor = new EditBlogPostInteractor(stubBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            stubBlogPostRepo.StubGetById(stub_BlogPost);
            var expected = MakeResponse(stub_BlogPost, true);
            var param_request = MakeRequest(stub_BlogPost);

            var actual = interactor.EditBlogPost(param_request);

            Assert.Equal(expected.EditSuccessful, actual.EditSuccessful);
            Assert.Equal(expected.Post.AuthorId, actual.Post.AuthorId);
            Assert.Equal(expected.Post.PostBody, actual.Post.PostBody);
            Assert.Equal(expected.Post.PostTitle, actual.Post.PostTitle);
            Assert.Equal(expected.Post.TimeCreated, actual.Post.TimeCreated);
        }

        [Fact]
        public void EditBlogPost_VerifyRepository()
        {
            var mockBlogPostRepo = new MockIBlogPostRepository();
            var interactor = new EditBlogPostInteractor(mockBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            mockBlogPostRepo.StubGetById(stub_BlogPost);
            var param_request = MakeRequest(stub_BlogPost);

            var response = interactor.EditBlogPost(param_request);

            mockBlogPostRepo.VerifyEdit(response.Post);
            mockBlogPostRepo.VerifyGetById(stub_BlogPost.PostId);
        }

        private EditBlogPostRequest MakeRequest(BlogPost stub)
        {
            return new EditBlogPostRequest
            {
                PostBody = stub.PostBody,
                PostId = stub.PostId,
                PostTitle = stub.PostTitle
            };
        }

        private EditBlogPostResponse MakeResponse(BlogPost post, bool requestSuccessful)
        {
            return new EditBlogPostResponse
            {
                Post = post,
                EditSuccessful = requestSuccessful
            };
        }
    }
}