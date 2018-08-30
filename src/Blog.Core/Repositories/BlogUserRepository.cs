using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogUserFileRepository : IBlogUserRepository
    {
        private readonly IBlogUserDataAccessAdapter _dataAccessAdapter;

        public BlogUserFileRepository(IBlogUserDataAccessAdapter dataAccessAdapter)
        {
            _dataAccessAdapter = dataAccessAdapter;
        }

        public void Add(BlogUser entity)
        {
            _dataAccessAdapter.Add(entity);
        }

        public void Delete(BlogUser entity)
        {
            _dataAccessAdapter.Delete(entity);
        }

        public void Edit(BlogUser entity)
        {
            _dataAccessAdapter.Edit(entity);
        }

        public BlogUser GetById(Guid id)
        {
            return _dataAccessAdapter.GetById(id);
        }

        public List<BlogUser> List()
        {
            return _dataAccessAdapter.List();
        }
    }
}