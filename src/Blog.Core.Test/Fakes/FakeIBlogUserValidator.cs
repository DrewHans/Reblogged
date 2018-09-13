using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIBlogUserValidator : IBlogUserValidator
    {
        protected readonly Mock<IBlogUserValidator> _mockIBlogUserValidator;

        public FakeIBlogUserValidator()
        {
            _mockIBlogUserValidator = new Mock<IBlogUserValidator>();
        }

        public void ValidateBlogUser(BlogUser blogUser)
        {
            _mockIBlogUserValidator.Object.ValidateBlogUser(blogUser);
        }
    }
}
