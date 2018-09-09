using Moq;

namespace Blog.Core.Test.Mocks
{
    public class MockIBlogUserValidator : IBlogUserValidator
    {
        private readonly Mock<IBlogUserValidator> _mockIBlogUserValidator;

        public MockIBlogUserValidator()
        {
            _mockIBlogUserValidator = new Mock<IBlogUserValidator>();
        }

        public void ValidateBlogUser(BlogUser blogUser)
        {
            _mockIBlogUserValidator.Object.ValidateBlogUser(blogUser);
        }

        public void VerifyValidateBlogUser(BlogUser blogUser)
        {
            _mockIBlogUserValidator.Verify(x => x.ValidateBlogUser(blogUser));
        }
    }
}
