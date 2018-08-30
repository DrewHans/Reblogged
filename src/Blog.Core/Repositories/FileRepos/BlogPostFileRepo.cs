using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Core
{
    public class BlogPostFileRepo : IBlogPostRepo
    {
        private readonly IConfiguration _configuration;
        private readonly IFileDatabase<BlogPost> _fileDatabase;
        private readonly string _filePathConfigKey;

        public BlogPostFileRepo(IConfiguration configuration, IFileDatabase<BlogPost> fileDatabase)
        {
            _configuration = configuration;
            _fileDatabase = fileDatabase;
            _filePathConfigKey = _configuration["filedatabase_blogpost_path"];
        }

        public void Add(BlogPost entity)
        {
            var filePath = _configuration[_filePathConfigKey];
            _fileDatabase.WriteToDatabase(filePath, entity);
        }

        public void Delete(BlogPost entity)
        {
            var listFromDatabase = List();
            var newList = GetNewListWithoutBlogPost(listFromDatabase, entity);
            var filePath = _configuration[_filePathConfigKey];
            _fileDatabase.OverwriteDatabase(filePath, newList);
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            var listFromDatabase = List();
            var newList = listFromDatabase
                .Where(blogPost =>
                    (blogPost.AuthorId.Equals(id)) == false)
                .ToList();
            var filePath = _configuration[_filePathConfigKey];
            _fileDatabase.OverwriteDatabase(filePath, newList);
        }

        public void Edit(BlogPost entity)
        {
            var listFromDatabase = List();
            var newList = GetNewListWithoutBlogPost(listFromDatabase, entity);
            newList.Add(entity);
            var filePath = _configuration[_filePathConfigKey];
            _fileDatabase.OverwriteDatabase(filePath, newList);
        }

        public BlogPost GetById(Guid id)
        {
            return List()
                .FirstOrDefault(blogPost =>
                    blogPost.PostId.Equals(id));
        }

        public List<BlogPost> List()
        {
            var filePath = _configuration[_filePathConfigKey];
            return _fileDatabase.ReadDatabase(filePath);
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