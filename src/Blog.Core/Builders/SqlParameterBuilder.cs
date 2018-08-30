using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Blog.Core
{
    public class SqlParameterBuilder<T> : ISqlParameterBuilder<T>
    {
        public SqlParameter BuildSqlParameter(string propertyName, object propertyValue)
        {
            var propertyAttribute = typeof(T)
                .GetProperty(propertyName)
                .GetCustomAttributes(typeof(SqlColumnAttribute), false)
                .FirstOrDefault() as SqlColumnAttribute;
            if (propertyAttribute == null)
                return null;
            var sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = $"@{propertyAttribute.ColumnName}";
            sqlParameter.SqlDbType = propertyAttribute.SqlDbType;
            sqlParameter.Value = propertyValue;
            return sqlParameter;
        }
    }
}