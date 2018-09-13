using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIBlogUserDataAccessAdapter : IBlogUserDataAccessAdapter
    {
        protected readonly Mock<IBlogUserDataAccessAdapter> _mockIBlogUserDataAccessAdapter;

        public FakeIBlogUserDataAccessAdapter()
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
    }
}
