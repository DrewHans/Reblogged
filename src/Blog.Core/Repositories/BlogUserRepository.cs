using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogUserRepository : IBlogUserRepository
    {
        private readonly IBlogUserDataAccessAdapter _dataAccessAdapter;
        private readonly IBlogUserValidator _validator;

        public BlogUserRepository(IBlogUserDataAccessAdapter dataAccessAdapter,
            IBlogUserValidator validator)
        {
            _dataAccessAdapter = dataAccessAdapter;
            _validator = validator;
        }

        public void Add(BlogUser entity)
        {
            _validator.ValidateBlogUser(entity);
            _dataAccessAdapter.Add(entity);
        }

        public void Delete(BlogUser entity)
        {
            _validator.ValidateBlogUser(entity);
            _dataAccessAdapter.Delete(entity);
        }

        public void Edit(BlogUser entity)
        {
            _validator.ValidateBlogUser(entity);
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