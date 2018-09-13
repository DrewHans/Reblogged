using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIBlogPostDataAccessAdapter : IBlogPostDataAccessAdapter
    {
        protected readonly Mock<IBlogPostDataAccessAdapter> _mockIBlogPostDataAccessAdapter;

        public FakeIBlogPostDataAccessAdapter()
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
    }
}
