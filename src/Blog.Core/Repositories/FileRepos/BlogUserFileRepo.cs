using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Core
{
    public class BlogUserFileRepo : IBlogUserRepo
    {
        private readonly IConfiguration _configuration;
        private readonly IFileDatabase<BlogUser> _fileDatabase;
        private readonly string _filePathConfigKey;

        public BlogUserFileRepo(IConfiguration configuration, IFileDatabase<BlogUser> fileDatabase)
        {
            _configuration = configuration;
            _fileDatabase = fileDatabase;
            _filePathConfigKey = "filedatabase_bloguser_path";
        }

        public void Add(BlogUser entity)
        {
            var filePath = _configuration[_filePathConfigKey];
            _fileDatabase.WriteToDatabase(filePath, entity);
        }

        public void Delete(BlogUser entity)
        {
            var listFromDatabase = List();
            var newList = GetNewListWithoutBlogUser(listFromDatabase, entity);
            var filePath = _configuration[_filePathConfigKey];
            _fileDatabase.OverwriteDatabase(filePath, newList);
        }

        public void Edit(BlogUser entity)
        {
            var listFromDatabase = List();
            var newList = GetNewListWithoutBlogUser(listFromDatabase, entity);
            newList.Add(entity);
            var filePath = _configuration[_filePathConfigKey];
            _fileDatabase.OverwriteDatabase(filePath, newList);
        }

        public BlogUser GetById(Guid id)
        {
            return List()
                .FirstOrDefault(blogUser =>
                    blogUser.UserId.Equals(id));
        }
        public List<BlogUser> List()
        {
            var filePath = _configuration[_filePathConfigKey];
            return _fileDatabase.ReadDatabase(filePath);
        }

        private List<BlogUser> GetNewListWithoutBlogUser(List<BlogUser> listOfBlogUser, BlogUser entity)
        {
            return listOfBlogUser
                .Where(blogUser =>
                    (blogUser.UserId.Equals(entity.UserId)) == false)
                .ToList();
        }
    }
}