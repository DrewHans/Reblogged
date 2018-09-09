using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostSqlServerAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockISqlParameterBuilder _mockSqlParameterBuilder;
        private MockISqlServerDataAccess _mockSqlServerDataAccess;
        private readonly BlogPostSqlServerAdapter _blogPostAdapter;

        public BlogPostSqlServerAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockSqlParameterBuilder = new MockISqlParameterBuilder();
            _mockSqlServerDataAccess = new MockISqlServerDataAccess();
            _blogPostAdapter = new BlogPostSqlServerAdapter(_stubConfiguration,
                _mockSqlServerDataAccess, _mockSqlParameterBuilder);
        }

        public void Dispose() { }

        [Fact]
        public void Add_VerifyMethodsCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_list = new List<SqlParameter>();
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogPost>(stub_list);
            var stub_rowsAffected = 1;
            _mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(stub_rowsAffected);
            _blogPostAdapter.Add(param_entity);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(6);
            _mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void Delete_VerifyMethodsCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_list = new List<SqlParameter>();
            stub_list.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogPost>(stub_list);
            var stub_rowsAffected = 1;
            _mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(stub_rowsAffected);
            _blogPostAdapter.Delete(param_entity);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
            _mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void DeleteByAuthorId_VerifyMethodsCalled()
        {
            var param_authorid = new StubBlogPost().AuthorId;
            var stub_list = new List<SqlParameter>();
            stub_list.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogPost>(stub_list);
            var stub_rowsAffected = 1;
            _mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(stub_rowsAffected);
            _blogPostAdapter.DeleteAllByAuthorId(param_authorid);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
            _mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void Edit_VerifyMethodsCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_list = new List<SqlParameter>();
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            stub_list.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogPost>(stub_list);
            var stub_rowsAffected = 1;
            _mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(stub_rowsAffected);
            _blogPostAdapter.Edit(param_entity);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(6);
            _mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogPost_VerifyMethodsCalledAndReturnsBlogPost()
        {
            var param_id = new StubBlogPost().PostId;
            var stub_listOfSqlParams = new List<SqlParameter>();
            stub_listOfSqlParams.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogPost>(stub_listOfSqlParams);
            var expected_blogpost = new StubBlogPost() as BlogPost;
            var stub_listOfBlogPost = new List<BlogPost> { expected_blogpost };
            _mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);
            var returned_blogpost = _blogPostAdapter.GetById(param_id);
            Assert.Equal(expected_blogpost, returned_blogpost);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
            _mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_VerifyMethodsCalledAndReturnsNull()
        {
            var param_id = new StubBlogPost().PostId;
            var stub_listOfSqlParams = new List<SqlParameter>();
            stub_listOfSqlParams.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogPost>(stub_listOfSqlParams);
            var stub_listOfBlogPost = new List<BlogPost>();
            _mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);
            var returned_blogpost = _blogPostAdapter.GetById(param_id);
            Assert.Null(returned_blogpost);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
            _mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void List_VerifyMethodsCalledAndReturnsList()
        {
            var stub_blogpost = new StubBlogPost() as BlogPost;
            var expected_listOfBlogPost = new List<BlogPost> { stub_blogpost };
            _mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected_listOfBlogPost);
            var returned_listOfBlogpost = _blogPostAdapter.List();
            Assert.Equal(expected_listOfBlogPost, returned_listOfBlogpost);
            _mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void ListByAuthorId_VerifyMethodsCalledAndReturnsList()
        {
            var stub_listOfSqlParams = new List<SqlParameter>();
            stub_listOfSqlParams.Add(MakeNewSqlParameter());
            _mockSqlParameterBuilder.StubBuildSqlParameter<BlogPost>(stub_listOfSqlParams);
            var stub_blogpost = new StubBlogPost() as BlogPost;
            var expected_listOfBlogPost = new List<BlogPost> { stub_blogpost };
            _mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected_listOfBlogPost);
            var returned_listOfBlogpost = _blogPostAdapter.ListByAuthorId(stub_blogpost.AuthorId);
            Assert.Equal(expected_listOfBlogPost, returned_listOfBlogpost);
            _mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
            _mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        private SqlParameter MakeNewSqlParameter()
        {
            // Due to more Microsoft shenanigans SqlParameter class has
            // the 'sealed' keyword. Therefore we cannot create a stub 
            // class for SqlParameter like we did for BlogPost and BlogUser.
            var stub_sqlParameter = new SqlParameter();
            stub_sqlParameter.ParameterName = "Stub Name";
            stub_sqlParameter.SqlDbType = SqlDbType.NChar;
            stub_sqlParameter.Value = "Stub Value";
            return stub_sqlParameter;
        }
    }
}
