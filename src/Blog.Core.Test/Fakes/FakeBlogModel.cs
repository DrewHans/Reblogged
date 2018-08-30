using System;
using System.Data;

namespace Blog.Core.Test.Fakes
{
    [SqlTable(TableName = "faketable")]
    public class FakeBlogModel
    {
        [SqlColumn(ColumnName = "fakecolumn", SqlDbType = SqlDbType.NChar)]
        public string FakeProperty { get; set; } = "fake value";
    }
}