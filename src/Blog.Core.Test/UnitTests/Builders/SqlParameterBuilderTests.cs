using Blog.Core.Test.Fakes;
using System;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace Blog.Core.Test
{
    public class SqlParameterBuilderTests : IDisposable
    {
        private readonly SqlParameterBuilder _sqlParameterBuilder;

        public SqlParameterBuilderTests()
        {
            _sqlParameterBuilder = new SqlParameterBuilder();
        }

        public void Dispose() { }

        [Fact]
        public void BuildSqlParameter_ModelWithAttributes_ReturnsExpectedSqlParameter()
        {
            var fakeModelWithAttributes = new FakeBlogModel();
            var param_propertyName = "FakeProperty";
            var param_propertyValue = fakeModelWithAttributes.FakeProperty;
            var expected = new SqlParameter
            {
                ParameterName = "@fakecolumn",
                SqlDbType = SqlDbType.NChar,
                Value = param_propertyValue
            };
            var actual = _sqlParameterBuilder.BuildSqlParameter<FakeBlogModel>(param_propertyName, param_propertyValue);
            AssertSqlParameterEqual(expected, actual);
        }

        private void AssertSqlParameterEqual(SqlParameter expected, SqlParameter actual)
        {
            Assert.Equal(expected.ParameterName, actual.ParameterName);
            Assert.Equal(expected.SqlDbType, actual.SqlDbType);
            Assert.Equal(expected.Value, actual.Value);
        }
    }
}