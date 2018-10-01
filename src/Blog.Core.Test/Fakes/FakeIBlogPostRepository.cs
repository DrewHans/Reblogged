using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIBlogPostRepository : IBlogPostRepository
    {
        protected readonly Mock<IBlogPostRepository> _mockIBlogPostRepository;

        public FakeIBlogPostRepository()
        {
            _mockIBlogPostRepository = new Mock<IBlogPostRepository>();
        }

        public void Add(BlogPost entity)
        {
            _mockIBlogPostRepository.Object.Add(entity);
        }

        public void Delete(BlogPost entity)
        {
            _mockIBlogPostRepository.Object.Delete(entity);
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            _mockIBlogPostRepository.Object.DeleteAllByAuthorId(id);
        }

        public void Edit(BlogPost entity)
        {
            _mockIBlogPostRepository.Object.Edit(entity);
        }

        public BlogPost GetById(Guid id)
        {
            return _mockIBlogPostRepository.Object.GetById(id);
        }

        public List<BlogPost> List()
        {
            return _mockIBlogPostRepository.Object.List();
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            return _mockIBlogPostRepository.Object.ListByAuthorId(id);
        }
    }
}
