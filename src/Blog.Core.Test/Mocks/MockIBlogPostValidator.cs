using Moq;

namespace Blog.Core.Test.Mocks
{
    public class MockIBlogPostValidator : IBlogPostValidator
    {
        private readonly Mock<IBlogPostValidator> _mockIBlogPostValidator;

        public MockIBlogPostValidator()
        {
            _mockIBlogPostValidator = new Mock<IBlogPostValidator>();
        }

        public void ValidateBlogPost(BlogPost blogPost)
        {
            _mockIBlogPostValidator.Object.ValidateBlogPost(blogPost);
        }

        public void VerifyValidateBlogPost(BlogPost blogPost)
        {
            _mockIBlogPostValidator.Verify(x => x.ValidateBlogPost(blogPost));
        }
    }
}
