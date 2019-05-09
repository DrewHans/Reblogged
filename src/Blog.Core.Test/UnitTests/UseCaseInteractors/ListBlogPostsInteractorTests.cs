using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class ListBlogPostsInteractorTests
    {
        [Fact]
        public void ListBlogPosts_ReturnsExpectedResponse()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var interactor = new ListBlogPostsInteractor(stubBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_listOfPosts = new List<BlogPost> { stub_BlogPost };
            stubBlogPostRepo.StubList(stub_listOfPosts);
            var expected = MakeResponse(stub_listOfPosts, true);
            var param_request = MakeRequest(stub_BlogPost);

            var actual = interactor.ListBlogPosts(param_request);

            Assert.Equal(expected.RequestSuccessful, actual.RequestSuccessful);
            Assert.Equal(expected.ListOfPosts, actual.ListOfPosts);
        }

        [Fact]
        public void ListBlogPosts_VerifyBlogPostRepository()
        {
            var mockBlogPostRepo = new MockIBlogPostRepository();
            var interactor = new ListBlogPostsInteractor(mockBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_listOfPosts = new List<BlogPost> { stub_BlogPost };
            mockBlogPostRepo.StubList(stub_listOfPosts);
            var expected = MakeResponse(stub_listOfPosts, true);
            var param_request = MakeRequest(stub_BlogPost);

            var response = interactor.ListBlogPosts(param_request);

            mockBlogPostRepo.VerifyList();
        }


        private ListBlogPostsRequest MakeRequest(BlogPost stub)
        {
            return new ListBlogPostsRequest();
        }

        private ListBlogPostsResponse MakeResponse(List<BlogPost> listOfPosts, bool requestSuccessful)
        {
            return new ListBlogPostsResponse
            {
                ListOfPosts = listOfPosts,
                RequestSuccessful = requestSuccessful
            };
        }
    }
}