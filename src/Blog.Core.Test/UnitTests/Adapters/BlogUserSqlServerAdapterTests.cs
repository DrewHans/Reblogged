using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserSqlServerAdapterTests
    {
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
        public void GetById_ListReturnedContainsBlogUser_VerifySqlParameterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_id = new BlogUserFactory().Create().UserId;
            var expected_blogpost = new BlogUserFactory().Create();
            var stub_listOfBlogUser = new List<BlogUser> { expected_blogpost };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Equal(expected_blogpost, returned_blogpost);
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
            var param_id = new BlogUserFactory().Create().UserId;
            var expected_blogpost = new BlogUserFactory().Create();
            var stub_listOfBlogUser = new List<BlogUser> { expected_blogpost };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Equal(expected_blogpost, returned_blogpost);
            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
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

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Null(returned_blogpost);
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

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Null(returned_blogpost);
            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
        }

        [Fact]
        public void List_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogUserSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var expected_listOfBlogUser = new List<BlogUser> { new BlogUserFactory().Create() };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected_listOfBlogUser);

            var returned_listOfBlogpost = sqlServerAdapter.List();

            Assert.Equal(expected_listOfBlogUser, returned_listOfBlogpost);
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
