using System.Data.SqlClient;
using System.Linq;

namespace Blog.Core
{
    public class SqlParameterBuilder : ISqlParameterBuilder
    {
        public SqlParameter BuildSqlParameter<T>(string propertyName, object propertyValue)
        {
            var propertyAttribute = typeof(T)
                .GetProperty(propertyName)
                .GetCustomAttributes(typeof(SqlColumnAttribute), false)
                .FirstOrDefault() as SqlColumnAttribute;
            if (propertyAttribute == null)
                throw new MissingAttributeException(typeof(SqlColumnAttribute));
            var sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = $"@{propertyAttribute.ColumnName}";
            sqlParameter.SqlDbType = propertyAttribute.SqlDbType;
            sqlParameter.Value = propertyValue;
            return sqlParameter;
        }
    }
}