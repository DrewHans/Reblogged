using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IBlogPostDataAccessAdapter _dataAccessAdapter;
        private readonly IBlogPostValidator _validator;

        public BlogPostRepository(IBlogPostDataAccessAdapter dataAccessAdapter,
            IBlogPostValidator validator)
        {
            _dataAccessAdapter = dataAccessAdapter;
            _validator = validator;
        }

        public void Add(BlogPost entity)
        {
            _validator.ValidateBlogPost(entity);
            _dataAccessAdapter.Add(entity);
        }

        public void Delete(BlogPost entity)
        {
            _validator.ValidateBlogPost(entity);
            _dataAccessAdapter.Delete(entity);
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            _dataAccessAdapter.DeleteAllByAuthorId(id);
        }

        public void Edit(BlogPost entity)
        {
            _validator.ValidateBlogPost(entity);
            _dataAccessAdapter.Edit(entity);
        }

        public BlogPost GetById(Guid id)
        {
            return _dataAccessAdapter.GetById(id);
        }

        public List<BlogPost> List()
        {
            return _dataAccessAdapter.List();
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            return _dataAccessAdapter.ListByAuthorId(id);
        }
    }
}