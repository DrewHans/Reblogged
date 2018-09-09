using System;
using Xunit;

namespace Blog.Core.Test
{
    public class DataAccessExceptionTests : IDisposable
    {
        public void Dispose() { }

        [Fact]
        public void DataAccessException_InitTest()
        {
            var expected_innerException = new Exception("There's a glitch in the matrix.");
            var dataAccessException = new DataAccessException(expected_innerException);
            var actual_innerException = dataAccessException.InnerException;
            Assert.Equal(expected_innerException, actual_innerException);
        }
    }
}