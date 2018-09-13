using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIBlogPostValidator : IBlogPostValidator
    {
        protected readonly Mock<IBlogPostValidator> _mockIBlogPostValidator;

        public FakeIBlogPostValidator()
        {
            _mockIBlogPostValidator = new Mock<IBlogPostValidator>();
        }

        public void ValidateBlogPost(BlogPost blogPost)
        {
            _mockIBlogPostValidator.Object.ValidateBlogPost(blogPost);
        }
    }
}
