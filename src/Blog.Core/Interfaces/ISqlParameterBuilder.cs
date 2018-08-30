using System.Data.SqlClient;

namespace Blog.Core
{
    public interface ISqlParameterBuilder<T>
    {
        SqlParameter BuildSqlParameter(string propertyName, object propertyValue);
    }
}