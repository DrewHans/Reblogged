using Moq;

namespace Blog.Core.Test.Fakes
{
    public class MockISqlParameterBuilder : StubISqlParameterBuilder
    {
        public void VerifyBuildSqlParameter<T>(string propertyName, object propertyValue)
        {
            _mockISqlParameterBuilder
                .Verify(x => x.BuildSqlParameter<T>(propertyName, propertyValue));
        }

        public void VerifyBuildSqlParameterCalled<T>(int timesCalled)
        {
            _mockISqlParameterBuilder
                .Verify(x => x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyBuildSqlParameterNeverCalled<T>()
        {
            _mockISqlParameterBuilder
                .Verify(x => x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()),
                    Times.Never());
        }
    }
}
