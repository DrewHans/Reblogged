using System.Data.SqlClient;

namespace Blog.Core
{
    public interface ISqlParameterBuilder
    {
        SqlParameter BuildSqlParameter<T>(string propertyName, object propertyValue);
    }
}