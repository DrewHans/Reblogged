using Moq;
using System;
using System.Collections.Generic;

namespace Blog.Core.Test.Mocks
{
    public class MockIBlogUserDataAccessAdapter : IBlogUserDataAccessAdapter
    {
        private readonly Mock<IBlogUserDataAccessAdapter> _mockIBlogUserDataAccessAdapter;

        public MockIBlogUserDataAccessAdapter()
        {
            _mockIBlogUserDataAccessAdapter = new Mock<IBlogUserDataAccessAdapter>();
        }

        public void Add(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter.Object.Add(entity);
        }

        public void Delete(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter.Object.Delete(entity);
        }

        public void Edit(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter.Object.Edit(entity);
        }

        public BlogUser GetById(Guid id)
        {
            return _mockIBlogUserDataAccessAdapter.Object.GetById(id);
        }

        public List<BlogUser> List()
        {
            return _mockIBlogUserDataAccessAdapter.Object.List();
        }

        public MockIBlogUserDataAccessAdapter StubGetById(BlogUser stub)
        {
            _mockIBlogUserDataAccessAdapter
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(stub);
            return this;
        }

        public MockIBlogUserDataAccessAdapter StubList(List<BlogUser> stub)
        {
            _mockIBlogUserDataAccessAdapter
                .Setup(x => x.List())
                .Returns(stub);
            return this;
        }

        public void VerifyAdd(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter.Verify(x => x.Add(entity));
        }

        public void VerifyDelete(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter.Verify(x => x.Delete(entity));
        }

        public void VerifyEdit(BlogUser entity)
        {
            _mockIBlogUserDataAccessAdapter.Verify(x => x.Edit(entity));
        }

        public void VerifyGetById(Guid id)
        {
            _mockIBlogUserDataAccessAdapter.Verify(x => x.GetById(id));
        }

        public void VerifyList()
        {
            _mockIBlogUserDataAccessAdapter.Verify(x => x.List());
        }
    }
}