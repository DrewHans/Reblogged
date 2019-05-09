using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class ListRecentBlogPostsInteractorTests
    {
        [Fact]
        public void ListRecentBlogPosts_ReturnsExpectedResponse()
        {
            var stubBlogPostRepo = new StubIBlogPostRepository();
            var interactor = new ListRecentBlogPostsInteractor(stubBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_listOfPosts = new List<BlogPost> { stub_BlogPost };
            stubBlogPostRepo.StubList(stub_listOfPosts);
            var expected = MakeResponse(stub_listOfPosts, true);
            var param_request = MakeRequest(stub_BlogPost);

            var actual = interactor.ListRecentBlogPosts(param_request);

            Assert.Equal(expected.RequestSuccessful, actual.RequestSuccessful);
            Assert.Equal(expected.ListOfRecentPosts, actual.ListOfRecentPosts);
        }

        [Fact]
        public void ListRecentBlogPosts_VerifyBlogPostRepository()
        {
            var mockBlogPostRepo = new MockIBlogPostRepository();
            var interactor = new ListRecentBlogPostsInteractor(mockBlogPostRepo);
            var stub_BlogPost = new BlogPostFactory().Create();
            var stub_listOfPosts = new List<BlogPost> { stub_BlogPost };
            mockBlogPostRepo.StubList(stub_listOfPosts);
            var expected = MakeResponse(stub_listOfPosts, true);
            var param_request = MakeRequest(stub_BlogPost);

            var response = interactor.ListRecentBlogPosts(param_request);

            mockBlogPostRepo.VerifyList();
        }


        private ListRecentBlogPostsRequest MakeRequest(BlogPost stub)
        {
            return new ListRecentBlogPostsRequest();
        }

        private ListRecentBlogPostsResponse MakeResponse(List<BlogPost> listOfPosts, bool requestSuccessful)
        {
            return new ListRecentBlogPostsResponse
            {
                ListOfRecentPosts = listOfPosts,
                RequestSuccessful = requestSuccessful
            };
        }
    }
}