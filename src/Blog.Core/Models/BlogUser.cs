using System;
using System.Collections.Generic;
using System.Data;

namespace Blog.Core
{
    [SqlTable(TableName = "bloguser")]
    public class BlogUser
    {
        [SqlColumn(ColumnName = "permissions", SqlDbType = SqlDbType.NVarChar)]
        public List<string> Permissions { get; set; } = new List<string>();

        [SqlColumn(ColumnName = "timeregistered", SqlDbType = SqlDbType.DateTime)]
        public DateTime TimeRegistered { get; set; }

        [SqlColumn(ColumnName = "id", SqlDbType = SqlDbType.NChar)]
        public Guid UserId { get; set; }

        [SqlColumn(ColumnName = "name", SqlDbType = SqlDbType.NChar)]
        public string UserName { get; set; }
    }
}