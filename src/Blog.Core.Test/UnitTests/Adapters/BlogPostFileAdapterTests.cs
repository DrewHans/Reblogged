using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostFileAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockIFileDataAccess<BlogPost> _mockFileDataAccess;
        private readonly BlogPostFileAdapter _blogPostAdapter;

        public BlogPostFileAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            _blogPostAdapter = new BlogPostFileAdapter(_stubConfiguration, _mockFileDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void sometest()
        {

        }
    }
}
