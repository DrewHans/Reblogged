using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIFileReader : IFileReader
    {
        protected readonly Mock<IFileReader> _mockIFileReader;

        public FakeIFileReader()
        {
            _mockIFileReader = new Mock<IFileReader>();
        }

        public string Read(string filepath)
        {
            return _mockIFileReader.Object.Read(filepath);
        }
    }
}
