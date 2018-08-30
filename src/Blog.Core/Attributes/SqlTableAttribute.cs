using System;

namespace Blog.Core
{
    public class SqlTableAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}