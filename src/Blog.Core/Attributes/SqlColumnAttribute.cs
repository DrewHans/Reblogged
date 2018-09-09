using System;
using System.Data;

namespace Blog.Core
{
    public class SqlColumnAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public SqlDbType SqlDbType { get; set; }
    }
}