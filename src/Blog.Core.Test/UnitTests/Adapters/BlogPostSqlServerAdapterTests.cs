using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostSqlServerAdapterTests
    {
        [Fact]
        public void Add_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Add(param_entity);
        }

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
        public void Delete_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Delete(param_entity);
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
        public void DeleteAllByAuthorId_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().AuthorId;
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.DeleteAllByAuthorId(param_id);
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
        public void Edit_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_entity = new BlogPostFactory().Create();
            stubSqlServerDataAccess.StubExecuteNonQueryStoredProcedure(1);

            sqlServerAdapter.Edit(param_entity);
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
        public void GetById_ListReturnedContainsBlogPost_ReturnsExpectedBlogPost()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var expected = new BlogPostFactory().Create();
            var stub_listOfBlogPost = new List<BlogPost> { expected };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);
            var param_id = expected.PostId;

            var actual = sqlServerAdapter.GetById(param_id);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_ListReturnedContainsBlogPost_VerifySqlParameterBuilder()
        {
            var fakeConfig = MakeFakeConfig();
            var mockSqlParameterBuilder = new MockISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, mockSqlParameterBuilder);
            var stub_blogpost = new BlogPostFactory().Create();
            var stub_listOfBlogPost = new List<BlogPost> { stub_blogpost };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);
            var param_id = stub_blogpost.PostId;

            sqlServerAdapter.GetById(param_id);

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
            var stub_blogpost = new BlogPostFactory().Create();
            var stub_listOfBlogPost = new List<BlogPost> { stub_blogpost };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);
            var param_id = stub_blogpost.PostId;

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void GetById_ListReturnedIsEmpty_ReturnsNullBlogPost()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().PostId;
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(new List<BlogPost>());

            var returned_blogpost = sqlServerAdapter.GetById(param_id);

            Assert.Null(returned_blogpost);
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

            sqlServerAdapter.GetById(param_id);

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

            sqlServerAdapter.GetById(param_id);

            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void List_ReturnsExpectedList()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var expected = new List<BlogPost> { new BlogPostFactory().Create() };
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
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                mockSqlServerDataAccess, stubSqlParameterBuilder);
            var stub_listOfBlogPost = new List<BlogPost> { new BlogPostFactory().Create() };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);

            sqlServerAdapter.List();

            mockSqlServerDataAccess.VerifyExecuteReaderStoredProcedureCalled<BlogPost>(1);
        }

        [Fact]
        public void ListByAuthorId_ReturnsExpectedList()
        {
            var fakeConfig = MakeFakeConfig();
            var stubSqlParameterBuilder = new StubISqlParameterBuilder();
            var stubSqlServerDataAccess = new StubISqlServerDataAccess();
            var sqlServerAdapter = new BlogPostSqlServerAdapter(fakeConfig,
                stubSqlServerDataAccess, stubSqlParameterBuilder);
            var param_id = new BlogPostFactory().Create().AuthorId;
            var expected = new List<BlogPost> { new BlogPostFactory().Create() };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(expected);

            var actual = sqlServerAdapter.ListByAuthorId(param_id);

            Assert.Equal(expected, actual);
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
            var stub_listOfBlogPost = new List<BlogPost> { new BlogPostFactory().Create() };
            stubSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);

            sqlServerAdapter.ListByAuthorId(param_id);

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
            var stub_listOfBlogPost = new List<BlogPost> { new BlogPostFactory().Create() };
            mockSqlServerDataAccess.StubExecuteReaderStoredProcedure(stub_listOfBlogPost);

            sqlServerAdapter.ListByAuthorId(param_id);

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
