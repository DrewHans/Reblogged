using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserSqlServerAdapterTests
    {
        [Fact]
        public void Add_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Add(param_entity);
        }

        [Fact]
        public void Add_VerifySqlParamaterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Add(param_entity);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(4);
        }

        [Fact]
        public void Add_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Add(param_entity);

            mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void Delete_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Delete(param_entity);
        }

        [Fact]
        public void Delete_VerifySqlParamaterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Delete(param_entity);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(1);
        }

        [Fact]
        public void Delete_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Delete(param_entity);

            mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void Edit_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Edit(param_entity);
        }

        [Fact]
        public void Edit_VerifySqlParamaterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Edit(param_entity);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(4);
        }

        [Fact]
        public void Edit_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogUserFactory().Create();
            mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Edit(param_entity);

            mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogUser_ReturnsExpectedBlogUser()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var expected = new BlogUserFactory().Create();
            var stub_listOfBlogUser = new List<BlogUser> { expected };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);
            var param_id = expected.UserId;

            var actual = sqlServerAdapter.GetById(param_id);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogUser_VerifySqlParameterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var stub_blogpost = new BlogUserFactory().Create();
            var stub_listOfBlogUser = new List<BlogUser> { stub_blogpost };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);
            var param_id = stub_blogpost.UserId;

            sqlServerAdapter.GetById(param_id);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(1);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogUser_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var stub_blogpost = new BlogUserFactory().Create();
            var stub_listOfBlogUser = new List<BlogUser> { stub_blogpost };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);
            var param_id = stub_blogpost.UserId;

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_ReturnsNullBlogUser()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogUserFactory().Create().UserId;
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(new List<BlogUser>());

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Null(returned_blogpost);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_VerifySqlParameterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_id = new BlogUserFactory().Create().UserId;
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(new List<BlogUser>());

            sqlServerAdapter.GetById(param_id);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(1);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogUserFactory().Create().UserId;
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(new List<BlogUser>());

            sqlServerAdapter.GetById(param_id);

            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
        }

        [Fact]
        public void List_ReturnsExpectedList()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var expected = new List<BlogUser> { new BlogUserFactory().Create() };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected);

            var actual = sqlServerAdapter.List();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var stub_listOfBlogUser = new List<BlogUser> { new BlogUserFactory().Create() };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);

            sqlServerAdapter.List();

            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
        }

        private FakeIConfiguration MakeFakeConfig()
        {
            return new FakeIConfigurationFactory()
                .StubFakeDataForSqlServerDataAccess()
                .Create();
        }
    }
}
