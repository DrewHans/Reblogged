using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IBlogPostDataAccessAdapter _dataAccessAdapter;

        public BlogPostRepository(IBlogPostDataAccessAdapter dataAccessAdapter)
        {
            _dataAccessAdapter = dataAccessAdapter;
        }

        public void Add(BlogPost entity)
        {
            _dataAccessAdapter.Add(entity);
        }

        public void Delete(BlogPost entity)
        {
            _dataAccessAdapter.Delete(entity);
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            _dataAccessAdapter.DeleteAllByAuthorId(id);
        }

        public void Edit(BlogPost entity)
        {
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