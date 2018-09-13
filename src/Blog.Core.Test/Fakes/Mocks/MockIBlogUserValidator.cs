using Moq;

namespace Blog.Core.Test.Fakes
{
    public class MockIBlogUserValidator : StubIBlogUserValidator
    {
        public void VerifyValidateBlogUser(BlogUser blogUser)
        {
            _mockIBlogUserValidator
                .Verify(x => x.ValidateBlogUser(blogUser));
        }

        public void VerifyValidateBlogUserCalled(int timesCalled)
        {
            _mockIBlogUserValidator
                .Verify(x => x.ValidateBlogUser(It.IsAny<BlogUser>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyValidateBlogUserNeverCalled()
        {
            _mockIBlogUserValidator
                .Verify(x => x.ValidateBlogUser(It.IsAny<BlogUser>()),
                    Times.Never());
        }
    }
}
