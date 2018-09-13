using Moq;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIFileWriter : IFileWriter
    {
        protected readonly Mock<IFileWriter> _mockIFileWriter;

        public FakeIFileWriter()
        {
            _mockIFileWriter = new Mock<IFileWriter>();
        }

        public void Write(string filepath, bool appendToFile, string value)
        {
            _mockIFileWriter.Object.Write(filepath, appendToFile, value);
        }
    }
}
