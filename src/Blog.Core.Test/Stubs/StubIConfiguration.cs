using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace Blog.Core.Test.Stubs
{
    public class StubIConfiguration : IConfiguration
    {
        private readonly IDictionary<string, string> _dictionary;

        public string this[string key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        public StubIConfiguration()
        {
            _dictionary = new Dictionary<string, string>();

            // stub key-value pairs for File Backed Repos
            _dictionary["filedatabase_blogpost_path"] = "fake/path/to/blogpost/database.json";
            _dictionary["filedatabase_bloguser_path"] = "fake/path/to/bloguser/database.json";

            // stub key-value pairs for Sql Backed Repos
            _dictionary["sqlserver_connectionstring"] = "Server=SomeServerName;Database=SomeDatabase;MoreSuperSecretFields=MoreSuperSecretValues;";
            _dictionary["sqlserver_storedprocedure_blogpost_add"] = "spBlogPostInsert";
            _dictionary["sqlserver_storedprocedure_blogpost_delete"] = "spBlogPostDelete";
            _dictionary["sqlserver_storedprocedure_blogpost_deleteallbyauthorid"] = "spBlogPostDeleteMany";
            _dictionary["sqlserver_storedprocedure_blogpost_edit"] = "spBlogPostUpdate";
            _dictionary["sqlserver_storedprocedure_blogpost_getbyid"] = "spBlogPostSelectById";
            _dictionary["sqlserver_storedprocedure_blogpost_list"] = "spBlogPostSelectAll";
            _dictionary["sqlserver_storedprocedure_blogpost_listbyauthorid"] = "spBlogPostSelectAllByAuthorId";
            _dictionary["sqlserver_storedprocedure_bloguser_add"] = "spBlogUserInsert";
            _dictionary["sqlserver_storedprocedure_bloguser_delete"] = "spBlogUserDelete";
            _dictionary["sqlserver_storedprocedure_bloguser_edit"] = "spBlogUserUpdate";
            _dictionary["sqlserver_storedprocedure_bloguser_getbyid"] = "spBlogUserSelectById";
            _dictionary["sqlserver_storedprocedure_bloguser_list"] = "spBlogUserSelectAll";
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new System.NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new System.NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
