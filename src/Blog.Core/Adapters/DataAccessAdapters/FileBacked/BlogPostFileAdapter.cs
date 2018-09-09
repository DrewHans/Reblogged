using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Core
{
    public class BlogPostFileAdapter : IBlogPostDataAccessAdapter
    {
        private readonly IConfiguration _configuration;
        private readonly IFileDataAccess<BlogPost> _fileDataAccess;

        public BlogPostFileAdapter(IConfiguration configuration, IFileDataAccess<BlogPost> fileDataAccess)
        {
            _configuration = configuration;
            _fileDataAccess = fileDataAccess;
        }

        public void Add(BlogPost entity)
        {
            var filePath = _configuration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            _fileDataAccess.WriteToDatabase(filePath, entity);
        }

        public void Delete(BlogPost entity)
        {
            var listFromDatabase = List();
            var newList = GetNewListWithoutBlogPost(listFromDatabase, entity);
            var filePath = _configuration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            _fileDataAccess.OverwriteDatabase(filePath, newList);
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            var listFromDatabase = List();
            var newList = listFromDatabase
                .Where(blogPost =>
                    (blogPost.AuthorId.Equals(id)) == false)
                .ToList();
            var filePath = _configuration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            _fileDataAccess.OverwriteDatabase(filePath, newList);
        }

        public void Edit(BlogPost entity)
        {
            var listFromDatabase = List();
            var newList = GetNewListWithoutBlogPost(listFromDatabase, entity);
            newList.Add(entity);
            var filePath = _configuration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            _fileDataAccess.OverwriteDatabase(filePath, newList);
        }

        public BlogPost GetById(Guid id)
        {
            return List()
                .FirstOrDefault(blogPost =>
                    blogPost.PostId.Equals(id));
        }

        public List<BlogPost> List()
        {
            var filePath = _configuration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            return _fileDataAccess.ReadDatabase(filePath);
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            return List()
                .Where(blogPost =>
                    blogPost.AuthorId.Equals(id))
                .ToList();
        }

        private List<BlogPost> GetNewListWithoutBlogPost(List<BlogPost> listOfBlogPost, BlogPost entity)
        {
            return listOfBlogPost
                .Where(blogPost =>
                    (blogPost.PostId.Equals(entity.PostId)) == false)
                .ToList();
        }
    }
}