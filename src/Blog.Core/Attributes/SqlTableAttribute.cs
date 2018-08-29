using System;

namespace Blog.Core
{
    public class SqlTableAttribute : Attribute
    {
        public string Name { get; set; }
    }
}