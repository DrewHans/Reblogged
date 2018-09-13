using System.Data;
using System.Data.SqlClient;

namespace Blog.Core.Test
{
    public class SqlParameterFactory : IFactory<SqlParameter>
    {
        private readonly SqlParameter _sqlParam;

        public SqlParameterFactory()
        {
            _sqlParam = new SqlParameter
            {
                ParameterName = "Stub Name",
                SqlDbType = SqlDbType.NChar,
                Value = "Stub Value"
            };
        }

        public SqlParameter Create()
        {
            return _sqlParam;
        }
    }
}
