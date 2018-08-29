using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogUserFileRepo : IBlogUserRepo
    {

        public BlogUserFileRepo()
        {
        }

        public void Add(BlogUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BlogUser entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(BlogUser entity)
        {
            throw new NotImplementedException();
        }

        public BlogUser GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string GetPasswordHashById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string GetPasswordSaltById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogUser> List()
        {
            throw new NotImplementedException();
        }
    }
}