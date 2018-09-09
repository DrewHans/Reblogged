using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core.Test.Mocks
{
    public class MockISqlParameterBuilder : ISqlParameterBuilder
    {
        private readonly Mock<ISqlParameterBuilder> _mockISqlParameterBuilder;

        public MockISqlParameterBuilder()
        {
            _mockISqlParameterBuilder = new Mock<ISqlParameterBuilder>();
        }

        public SqlParameter BuildSqlParameter<T>(string propertyName, object propertyValue)
        {
            return _mockISqlParameterBuilder.Object.BuildSqlParameter<T>(propertyName, propertyValue);
        }

        public MockISqlParameterBuilder StubBuildSqlParameter<T>(List<SqlParameter> listOfStubs)
        {
            var stubSequence = _mockISqlParameterBuilder.SetupSequence(x =>
                x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public MockISqlParameterBuilder StubBuildSqlParameter<T>(SqlParameter stub)
        {
            _mockISqlParameterBuilder
                .Setup(x => x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(stub);
            return this;
        }

        public void VerifyBuildSqlParameter<T>(string propertyName, object propertyValue)
        {
            _mockISqlParameterBuilder.Verify(x =>
                x.BuildSqlParameter<T>(propertyName, propertyValue));
        }

        public void VerifyBuildSqlParameterCalled<T>()
        {
            _mockISqlParameterBuilder.Verify(x =>
                x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()));
        }

        public void VerifyBuildSqlParameterCalled<T>(int timesCalled)
        {
            _mockISqlParameterBuilder.Verify(x =>
                x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()),
                Times.Exactly(timesCalled));
        }
    }
}
