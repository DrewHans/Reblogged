using Moq;
using System;

namespace Blog.Core.Test.Fakes
{
    public class MockIBlogUserDataAccessAdapter : StubIBlogUserDataAccessAdapter
    {
        public void VerifyAdd(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Add(entity));
        }

        public void VerifyAddCalled(int timesCalled)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Add(It.IsAny<BlogUser>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyAddNeverCalled()
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Add(It.IsAny<BlogUser>()),
                    Times.Never());
        }

        public void VerifyDelete(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Delete(entity));
        }

        public void VerifyDeleteCalled(int timesCalled)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Delete(It.IsAny<BlogUser>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyDeleteNeverCalled()
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Delete(It.IsAny<BlogUser>()),
                    Times.Never());
        }

        public void VerifyEdit(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Edit(entity));
        }

        public void VerifyEditCalled(int timesCalled)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Edit(It.IsAny<BlogUser>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyEditNeverCalled()
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.Edit(It.IsAny<BlogUser>()),
                    Times.Never());
        }

        public void VerifyGetById(Guid id)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.GetById(id));
        }

        public void VerifyGetByIdCalled(int timesCalled)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.GetById(It.IsAny<Guid>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyGetByIdNeverCalled()
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.GetById(It.IsAny<Guid>()),
                    Times.Never());
        }

        public void VerifyList()
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.List());
        }

        public void VerifyListCalled(int timesCalled)
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.List(),
                    Times.Exactly(timesCalled));
        }

        public void VerifyListNeverCalled()
        {
            _mockIBlogUserDataAccessAdapter
                .Verify(x => x.List(),
                    Times.Never());
        }
    }
}
