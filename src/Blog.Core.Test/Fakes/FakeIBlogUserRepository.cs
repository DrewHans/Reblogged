using System;
using System.Collections.Generic;
using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIBlogUserRepository : IBlogUserRepository
    {
        protected readonly Mock<IBlogUserRepository> _mockIBlogUserRepository;

        public FakeIBlogUserRepository()
        {
            _mockIBlogUserRepository = new Mock<IBlogUserRepository>();
        }

        public void Add(BlogUser entity)
        {
            _mockIBlogUserRepository.Object.Add(entity);
        }

        public void Delete(BlogUser entity)
        {
            _mockIBlogUserRepository.Object.Delete(entity);
        }

        public void Edit(BlogUser entity)
        {
            _mockIBlogUserRepository.Object.Edit(entity);
        }

        public BlogUser GetById(Guid id)
        {
            return _mockIBlogUserRepository.Object.GetById(id);
        }

        public List<BlogUser> List()
        {
            return _mockIBlogUserRepository.Object.List();
        }
    }
}
