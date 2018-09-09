using System;
using Xunit;

namespace Blog.Core.Test
{
    public class MissingAttributeExceptionTests : IDisposable
    {
        public void Dispose() { }

        [Fact]
        public void MissingAttributeException_InitTest()
        {
            var expected_attributetype = new SqlColumnAttribute().GetType();
            var missingAttributeException = new MissingAttributeException(expected_attributetype);
            var actual_attributeTypeExpected = missingAttributeException.AttributeTypeExpected;
            Assert.Equal(expected_attributetype, actual_attributeTypeExpected);
        }
    }
}