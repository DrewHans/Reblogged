using Moq;
using System;
using System.Collections.Generic;

namespace Blog.Core.Test.Mocks
{
    public class MockIBlogPostDataAccessAdapter : IBlogPostDataAccessAdapter
    {
        private readonly Mock<IBlogPostDataAccessAdapter> _mockIBlogPostDataAccessAdapter;

        public MockIBlogPostDataAccessAdapter()
        {
            _mockIBlogPostDataAccessAdapter = new Mock<IBlogPostDataAccessAdapter>();
        }

        public void Add(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter.Object.Add(entity);
        }

        public void Delete(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter.Object.Delete(entity);
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            _mockIBlogPostDataAccessAdapter.Object.DeleteAllByAuthorId(id);
        }

        public void Edit(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter.Object.Edit(entity);
        }

        public BlogPost GetById(Guid id)
        {
            return _mockIBlogPostDataAccessAdapter.Object.GetById(id);
        }

        public List<BlogPost> List()
        {
            return _mockIBlogPostDataAccessAdapter.Object.List();
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            return _mockIBlogPostDataAccessAdapter.Object.ListByAuthorId(id);
        }

        public MockIBlogPostDataAccessAdapter StubGetById(BlogPost stub)
        {
            _mockIBlogPostDataAccessAdapter
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public MockIBlogPostDataAccessAdapter StubList(List<BlogPost> stub)
        {
            _mockIBlogPostDataAccessAdapter
                .Setup(x => x.List())
                .Returns(stub);
            return this;
        }

        public MockIBlogPostDataAccessAdapter StubListByAuthorId(List<BlogPost> stub)
        {
            _mockIBlogPostDataAccessAdapter
                .Setup(x => x.ListByAuthorId(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public void VerifyAdd(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter.Verify(x => x.Add(entity));
        }

        public void VerifyDelete(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter.Verify(x => x.Delete(entity));
        }

        public void VerifyDeleteAllByAuthorId(Guid id)
        {
            _mockIBlogPostDataAccessAdapter.Verify(x => x.DeleteAllByAuthorId(id));
        }

        public void VerifyEdit(BlogPost entity)
        {
            _mockIBlogPostDataAccessAdapter.Verify(x => x.Edit(entity));
        }

        public void VerifyGetById(Guid id)
        {
            _mockIBlogPostDataAccessAdapter.Verify(x => x.GetById(id));
        }

        public void VerifyList()
        {
            _mockIBlogPostDataAccessAdapter.Verify(x => x.List());
        }

        public void VerifyListByAuthorId(Guid id)
        {
            _mockIBlogPostDataAccessAdapter.Verify(x => x.ListByAuthorId(id));
        }
    }
}