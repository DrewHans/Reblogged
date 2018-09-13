using Moq;
using System.Data.SqlClient;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeISqlParameterBuilder : ISqlParameterBuilder
    {
        private readonly Mock<ISqlParameterBuilder> _mockISqlParameterBuilder;

        public FakeISqlParameterBuilder()
        {
            _mockISqlParameterBuilder = new Mock<ISqlParameterBuilder>();
        }

        public SqlParameter BuildSqlParameter<T>(string propertyName, object propertyValue)
        {
            return _mockISqlParameterBuilder.Object.BuildSqlParameter<T>(propertyName, propertyValue);
        }
    }
}
