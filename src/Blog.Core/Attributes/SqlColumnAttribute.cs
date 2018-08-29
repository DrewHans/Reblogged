using System;
using System.Data;

namespace Blog.Core
{
    public class SqlColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; }
    }
}