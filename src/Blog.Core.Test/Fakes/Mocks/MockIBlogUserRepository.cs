using Moq;
using System;

namespace Blog.Core.Test.Fakes
{
    public class MockIBlogUserRepository : StubIBlogUserRepository
    {
        public void VerifyAdd(BlogUser entity)
        {
            _mockIBlogUserRepository
                .Verify(x => x.Add(entity));
        }

        public void VerifyAddCalled(int timesCalled)
        {
            _mockIBlogUserRepository
                .Verify(x => x.Add(It.IsAny<BlogUser>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyAddNeverCalled()
        {
            _mockIBlogUserRepository
                .Verify(x => x.Add(It.IsAny<BlogUser>()),
                    Times.Never());
        }

        public void VerifyDelete(BlogUser entity)
        {
            _mockIBlogUserRepository
                .Verify(x => x.Delete(entity));
        }

        public void VerifyDeleteCalled(int timesCalled)
        {
            _mockIBlogUserRepository
                .Verify(x => x.Delete(It.IsAny<BlogUser>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyDeleteNeverCalled()
        {
            _mockIBlogUserRepository
                .Verify(x => x.Delete(It.IsAny<BlogUser>()),
                    Times.Never());
        }

        public void VerifyEdit(BlogUser entity)
        {
            _mockIBlogUserRepository
                .Verify(x => x.Edit(entity));
        }

        public void VerifyEditCalled(int timesCalled)
        {
            _mockIBlogUserRepository
                .Verify(x => x.Edit(It.IsAny<BlogUser>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyEditNeverCalled()
        {
            _mockIBlogUserRepository
                .Verify(x => x.Edit(It.IsAny<BlogUser>()),
                    Times.Never());
        }

        public void VerifyGetById(Guid id)
        {
            _mockIBlogUserRepository
                .Verify(x => x.GetById(id));
        }

        public void VerifyGetByIdCalled(int timesCalled)
        {
            _mockIBlogUserRepository
                .Verify(x => x.GetById(It.IsAny<Guid>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyGetByIdNeverCalled()
        {
            _mockIBlogUserRepository
                .Verify(x => x.GetById(It.IsAny<Guid>()),
                    Times.Never());
        }

        public void VerifyList()
        {
            _mockIBlogUserRepository
                .Verify(x => x.List());
        }

        public void VerifyListCalled(int timesCalled)
        {
            _mockIBlogUserRepository
                .Verify(x => x.List(),
                    Times.Exactly(timesCalled));
        }

        public void VerifyListNeverCalled()
        {
            _mockIBlogUserRepository
                .Verify(x => x.List(),
                    Times.Never());
        }
    }
}
