using System;
using System.Collections.Generic;
using System.Data;

namespace Blog.Core
{
    [SqlTable(Name = "bloguser")]
    public class BlogUser
    {
        [SqlColumn(Name = "permissions", Type = SqlDbType.NVarChar)]
        public List<string> Permissions { get; set; } = new List<string>();

        [SqlColumn(Name = "timeregistered", Type = SqlDbType.DateTime)]
        public DateTime TimeRegistered { get; set; }

        [SqlColumn(Name = "id", Type = SqlDbType.NChar)]
        public Guid UserId { get; set; }

        [SqlColumn(Name = "name", Type = SqlDbType.NChar)]
        public string UserName { get; set; }
    }
}