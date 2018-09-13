using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core.Test.Fakes
{
    public class StubISqlParameterBuilder : FakeISqlParameterBuilder
    {
        public StubISqlParameterBuilder StubBuildSqlParameter<T>(SqlParameter stub)
        {
            _mockISqlParameterBuilder
                .Setup(x => x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(stub);
            return this;
        }

        public StubISqlParameterBuilder StubBuildSqlParameter<T>(List<SqlParameter> listOfStubs)
        {
            var stubSequence = _mockISqlParameterBuilder
                .SetupSequence(x => x.BuildSqlParameter<T>(It.IsAny<string>(), It.IsAny<object>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
