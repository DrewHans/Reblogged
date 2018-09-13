using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace Blog.Core.Test.Fakes
{
    public class FakeIConfiguration : IConfiguration
    {
        private readonly IDictionary<string, string> _dictionary;

        public string this[string key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        public FakeIConfiguration()
        {
            _dictionary = new Dictionary<string, string>();
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
