using Blog.Core.Test.Fakes;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace Blog.Core.Test
{
    public class FakeModelWithoutAttributes
    {
        public string FakeProperty { get; set; } = "fake value";
    }

    public class SqlParameterBuilderTests
    {
        [Fact]
        public void BuildSqlParameter_ModelWithAttributes_ReturnsExpectedSqlParameter()
        {
            var sqlParamBuilder = new SqlParameterBuilder();
            var fakeModelWithAttributes = new FakeBlogModel();
            var param_propertyName = "FakeProperty";
            var param_propertyValue = fakeModelWithAttributes.FakeProperty;
            var expected = new SqlParameter
            {
                ParameterName = "@fakecolumn",
                SqlDbType = SqlDbType.NChar,
                Value = param_propertyValue
            };

            var actual = sqlParamBuilder.BuildSqlParameter<FakeBlogModel>(param_propertyName, param_propertyValue);

            AssertSqlParameterEqual(expected, actual);
        }

        [Fact]
        public void BuildSqlParameter_ModelWithoutAttributes_ThrowsException()
        {
            var sqlParamBuilder = new SqlParameterBuilder();
            var fakeModelWithoutAttributes = new FakeModelWithoutAttributes();
            var param_propertyName = "FakeProperty";
            var param_propertyValue = fakeModelWithoutAttributes.FakeProperty;

            Assert.Throws<MissingAttributeException>(
                () => sqlParamBuilder.BuildSqlParameter<FakeModelWithoutAttributes>(
                    param_propertyName, param_propertyValue));
        }

        private void AssertSqlParameterEqual(SqlParameter expected, SqlParameter actual)
        {
            Assert.Equal(expected.ParameterName, actual.ParameterName);
            Assert.Equal(expected.SqlDbType, actual.SqlDbType);
            Assert.Equal(expected.Value, actual.Value);
        }
    }
}
