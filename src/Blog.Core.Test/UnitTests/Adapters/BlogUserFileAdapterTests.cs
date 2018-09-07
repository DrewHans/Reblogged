using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserFileAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockIFileDataAccess<BlogUser> _mockFileDataAccess;
        private readonly BlogUserFileAdapter _blogUserAdapter;

        public BlogUserFileAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockFileDataAccess = new MockIFileDataAccess<BlogUser>();
            _blogUserAdapter = new BlogUserFileAdapter(_stubConfiguration, _mockFileDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void sometest()
        {

        }
    }
}
