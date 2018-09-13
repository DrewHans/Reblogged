using Moq;
using System;

namespace Blog.Core.Test.Fakes
{
    public class MockIBlogPostDataAccessAdapter : StubIBlogPostDataAccessAdapter
    {
        public void VerifyAdd(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Add(entity));
        }

        public void VerifyAddCalled(int timesCalled)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Add(It.IsAny<BlogPost>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyAddNeverCalled()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Add(It.IsAny<BlogPost>()),
                    Times.Never());
        }

        public void VerifyDelete(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Delete(entity));
        }

        public void VerifyDeleteCalled(int timesCalled)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Delete(It.IsAny<BlogPost>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyDeleteNeverCalled()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Delete(It.IsAny<BlogPost>()),
                    Times.Never());
        }

        public void VerifyDeleteAllByAuthorId(Guid id)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.DeleteAllByAuthorId(id));
        }

        public void VerifyDeleteAllByAuthorIdCalled(int timesCalled)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.DeleteAllByAuthorId(It.IsAny<Guid>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyDeleteAllByAuthorIdNeverCalled()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.DeleteAllByAuthorId(It.IsAny<Guid>()),
                    Times.Never());
        }

        public void VerifyEdit(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Edit(entity));
        }

        public void VerifyEditCalled(int timesCalled)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Edit(It.IsAny<BlogPost>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyEditNeverCalled()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.Edit(It.IsAny<BlogPost>()),
                    Times.Never());
        }

        public void VerifyGetById(Guid id)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.GetById(id));
        }

        public void VerifyGetByIdCalled(int timesCalled)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.GetById(It.IsAny<Guid>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyGetByIdNeverCalled()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.GetById(It.IsAny<Guid>()),
                    Times.Never());
        }

        public void VerifyList()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.List());
        }

        public void VerifyListCalled(int timesCalled)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.List(),
                    Times.Exactly(timesCalled));
        }

        public void VerifyListNeverCalled()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.List(),
                    Times.Never());
        }

        public void VerifyListByAuthorId(Guid id)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.ListByAuthorId(id));
        }

        public void VerifyListByAuthorIdCalled(int timesCalled)
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.ListByAuthorId(It.IsAny<Guid>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyListByAuthorIdNeverCalled()
        {
            _mockIBlogPostDataAccessAdapter
                .Verify(x => x.ListByAuthorId(It.IsAny<Guid>()),
                    Times.Never());
        }
    }
}
