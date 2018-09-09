using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserSqlServerAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockISqlParameterBuilder _mockSqlParameterBuilder;
        private MockISqlServerDataAccess _mockSqlServerDataAccess;
        private readonly BlogUserSqlServerAdapter _blogUserAdapter;

        public BlogUserSqlServerAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockSqlParameterBuilder = new MockISqlParameterBuilder();
            _mockSqlServerDataAccess = new MockISqlServerDataAccess();
            _blogUserAdapter = new BlogUserSqlServerAdapter(_stubConfiguration,
                _mockSqlServerDataAccess, _mockSqlParameterBuilder);
        }

        public void Dispose() { }

        [Fact]
        public void Add_VerifyMethodsCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_list = new List<SqlParameter>();
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogUser>(stub_list);
            var stub_rowsAffected = 1;
            _mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(stub_rowsAffected);
            _blogUserAdapter.Add(param_entity);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(4);
            _mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void Delete_VerifyMethodsCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_list = new List<SqlParameter>();
            stub_list.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogUser>(stub_list);
            var stub_rowsAffected = 1;
            _mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(stub_rowsAffected);
            _blogUserAdapter.Delete(param_entity);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(1);
            _mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void Edit_VerifyMethodsCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_list = new List<SqlParameter>();
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogUser>(stub_list);
            var stub_rowsAffected = 1;
            _mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(stub_rowsAffected);
            _blogUserAdapter.Edit(param_entity);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(4);
            _mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogPost_VerifyMethodsCalledAndReturnsBlogPost()
        {
            var param_id = new StubBlogUser().UserId;
            var stub_listOfSqlParams = new List<SqlParameter>();
            stub_listOfSqlParams.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogUser>(stub_listOfSqlParams);
            var expected_blogpost = new StubBlogUser() as BlogUser;
            var stub_listOfBlogUser = new List<BlogUser> { expected_blogpost };
            _mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);
            var returned_blogpost = _blogUserAdapter.GetById(param_id);
            Assert.Equal(expected_blogpost, returned_blogpost);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(1);
            _mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_VerifyMethodsCalledAndReturnsNull()
        {
            var param_id = new StubBlogUser().UserId;
            var stub_listOfSqlParams = new List<SqlParameter>();
            stub_listOfSqlParams.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogUser>(stub_listOfSqlParams);
            var stub_listOfBlogUser = new List<BlogUser>();
            _mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogUser);
            var returned_blogpost = _blogUserAdapter.GetById(param_id);
            Assert.Null(returned_blogpost);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogUser>(1);
            _mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
        }

        [Fact]
        public void List_VerifyMethodsCalledAndReturnsList()
        {
            var stub_blogpost = new StubBlogUser() as BlogUser;
            var expected_listOfBlogUser = new List<BlogUser> { stub_blogpost };
            _mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected_listOfBlogUser);
            var returned_listOfBlogpost = _blogUserAdapter.List();
            Assert.Equal(expected_listOfBlogUser, returned_listOfBlogpost);
            _mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogUser>(1);
        }

        private SqlParameter MakeNewSqlParameter()
        {
            // Due to more Microsoft shenanigans SqlParameter class has
            // the 'sealed' keyword. Therefore we cannot create a stub 
            // class for SqlParameter like we did for BlogUser and BlogUser.
            var stub_sqlParameter = new SqlParameter();
            stub_sqlParameter.ParameterName = "Stub Name";
            stub_sqlParameter.SqlDbType = SqlDbType.NChar;
            stub_sqlParameter.Value = "Stub Value";
            return stub_sqlParameter;
        }
    }
}
