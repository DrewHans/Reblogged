using Moq;

namespace Blog.Core.Test.Fakes
{
    public class MockIBlogPostValidator : StubIBlogPostValidator
    {
        public void VerifyValidateBlogPost(BlogPost blogPost)
        {
            _mockIBlogPostValidator
                .Verify(x => x.ValidateBlogPost(blogPost));
        }

        public void VerifyValidateBlogPostCalled(int timesCalled)
        {
            _mockIBlogPostValidator
                .Verify(x => x.ValidateBlogPost(It.IsAny<BlogPost>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyValidateBlogPostNeverCalled()
        {
            _mockIBlogPostValidator
                .Verify(x => x.ValidateBlogPost(It.IsAny<BlogPost>()),
                    Times.Never());
        }
    }
}
