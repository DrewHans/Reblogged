using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Blog.Core
{
    public class BlogPostRestApiAdapter : IBlogPostDataAccessAdapter
    {
        private readonly IConfiguration _configuration;
        private readonly IRestApiDataAccess _restApiDataAccess;

        public BlogPostRestApiAdapter(IConfiguration configuration, IRestApiDataAccess restApiDataAccess)
        {
            _configuration = configuration;
            _restApiDataAccess = restApiDataAccess;
        }

        public void Add(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllByAuthorId(Guid id)
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

        public List<BlogPost> List()
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}