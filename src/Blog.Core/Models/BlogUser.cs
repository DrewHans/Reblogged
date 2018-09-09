using System;
using System.Collections.Generic;
using System.Data;

namespace Blog.Core
{
    [SqlTable(TableName = KeyChain.SqlServerDataAccess_BlogUser_TableName)]
    public class BlogUser
    {
        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogUser_ColumnName_Permissions,
            SqlDbType = SqlDbType.NVarChar)]
        public List<string> Permissions { get; set; } = new List<string>();

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogUser_ColumnName_TimeRegistered,
            SqlDbType = SqlDbType.DateTime)]
        public DateTime TimeRegistered { get; set; }

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogUser_ColumnName_UserId,
            SqlDbType = SqlDbType.NChar)]
        public Guid UserId { get; set; }

        [SqlColumn(
            ColumnName = KeyChain.SqlServerDataAccess_BlogUser_ColumnName_UserName,
            SqlDbType = SqlDbType.NChar)]
        public string UserName { get; set; }
    }
}