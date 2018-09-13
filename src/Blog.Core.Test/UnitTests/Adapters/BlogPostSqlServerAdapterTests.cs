using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostSqlServerAdapterTests
    {
        [Fact]
        public void Add_VerifySqlParamaterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Add(param_entity);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(6);
        }

        [Fact]
        public void Add_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
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
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Delete(param_entity);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
        }

        [Fact]
        public void Delete_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Delete(param_entity);

            mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void DeleteAllByAuthorId_VerifySqlParamaterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().AuthorId;
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.DeleteAllByAuthorId(param_id);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
        }

        [Fact]
        public void DeleteAllByAuthorId_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().AuthorId;
            mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.DeleteAllByAuthorId(param_id);

            mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void Edit_VerifySqlParamaterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Edit(param_entity);

            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(6);
        }

        [Fact]
        public void Edit_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            mockSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Edit(param_entity);

            mockSqlServerDataAccess.VerifyExecuteNonQueryStoredProcedureCalled(1);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogPost_VerifySqlParameterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().PostId;
            var expected_blogpost = new BlogPostFactory().Create();
            var stub_listOfBlogPost = new List<BlogPost> { expected_blogpost };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Equal(expected_blogpost, returned_blogpost);
            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogPost_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().PostId;
            var expected_blogpost = new BlogPostFactory().Create();
            var stub_listOfBlogPost = new List<BlogPost> { expected_blogpost };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Equal(expected_blogpost, returned_blogpost);
            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_VerifySqlParameterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().PostId;
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(new List<BlogPost>());

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Null(returned_blogpost);
            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().PostId;
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(new List<BlogPost>());

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Null(returned_blogpost);
            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void List_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var expected_listOfBlogPost = new List<BlogPost> { new BlogPostFactory().Create() };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected_listOfBlogPost);

            var returned_listOfBlogpost = sqlServerAdapter.List();

            Assert.Equal(expected_listOfBlogPost, returned_listOfBlogpost);
            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void ListByAuthorId_VerifySqlParameterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().AuthorId;
            var expected_listOfBlogPost = new List<BlogPost> { new BlogPostFactory().Create() };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected_listOfBlogPost);

            var returned_listOfBlogpost = sqlServerAdapter.ListByAuthorId(param_id);

            Assert.Equal(expected_listOfBlogPost, returned_listOfBlogpost);
            mockSqlParameterBuilder.VerifyBuildSqlParameterCalled<BlogPost>(1);
        }

        [Fact]
        public void ListByAuthorId_VerifySqlServerDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var mockSqlServerDataAccess = new MockISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().AuthorId;
            var expected_listOfBlogPost = new List<BlogPost> { new BlogPostFactory().Create() };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected_listOfBlogPost);

            var returned_listOfBlogpost = sqlServerAdapter.ListByAuthorId(param_id);

            Assert.Equal(expected_listOfBlogPost, returned_listOfBlogpost);
            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        private FakeIConfiguration MakeFakeConfig()
        {
            return new FakeIConfigurationFactory()
                .StubFakeDataForSqlServerDataAccess()
                .Create();
        }
    }
}
