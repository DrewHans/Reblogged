using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogPostSqlRepo : IBlogPostRepo
    {

        public BlogPostSqlRepo()
        {
        }

        public void Add(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public BlogPost GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogPost> List()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}