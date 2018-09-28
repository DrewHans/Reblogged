using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostRepositoryTests
    {
        [Fact]
        public void Add_ValidBlogPost_Returns()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, stubValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Add(param_blogPost);
        }

        [Fact]
        public void Add_ValidBlogPost_VerifyValidator()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var mockValidator = new MockIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, mockValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Add(param_blogPost);

            mockValidator.VerifyValidateBlogPost(param_blogPost);
        }

        [Fact]
        public void Add_ValidBlogPost_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Add(param_blogPost);

            mockDataAccessAdapter.VerifyAdd(param_blogPost);
        }

        [Fact]
        public void Delete_ValidBlogPost_Returns()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, stubValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Delete(param_blogPost);
        }

        [Fact]
        public void Delete_ValidBlogPost_VerifyValidator()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var mockValidator = new MockIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, mockValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Delete(param_blogPost);

            mockValidator.VerifyValidateBlogPost(param_blogPost);
        }

        [Fact]
        public void Delete_ValidBlogPost_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Delete(param_blogPost);

            mockDataAccessAdapter.VerifyDelete(param_blogPost);
        }

        [Fact]
        public void DeleteAllByAuthorId_ValidAuthorId_Returns()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, stubValidator);
            var param_authorId = new BlogPostFactory().Create().AuthorId;

            repository.DeleteAllByAuthorId(param_authorId);
        }

        [Fact]
        public void DeleteAllByAuthorId_ValidAuthorId_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);
            var param_authorId = new BlogPostFactory().Create().AuthorId;

            repository.DeleteAllByAuthorId(param_authorId);

            mockDataAccessAdapter.VerifyDeleteAllByAuthorId(param_authorId);
        }

        [Fact]
        public void Edit_ValidBlogPost_Returns()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, stubValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Edit(param_blogPost);
        }

        [Fact]
        public void Edit_ValidBlogPost_VerifyValidator()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var mockValidator = new MockIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, mockValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Edit(param_blogPost);

            mockValidator.VerifyValidateBlogPost(param_blogPost);
        }

        [Fact]
        public void Edit_ValidBlogPost_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);
            var param_blogPost = new BlogPostFactory().Create();

            repository.Edit(param_blogPost);

            mockDataAccessAdapter.VerifyEdit(param_blogPost);
        }

        [Fact]
        public void GetById_ValidBlogPost_ReturnsExpectedBlogPost()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, stubValidator);
            var expected = new BlogPostFactory().Create();
            stubDataAccessAdapter.StubGetById(expected);
            var param_authorId = expected.AuthorId;

            var actual = repository.GetById(param_authorId);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_ValidBlogPost_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);
            var param_authorId = new BlogPostFactory().Create().AuthorId;

            repository.GetById(param_authorId);

            mockDataAccessAdapter.VerifyGetById(param_authorId);
        }

        [Fact]
        public void List_ValidBlogPost_ReturnsExpectedList()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, stubValidator);
            var expected = new List<BlogPost> { new BlogPostFactory().Create() };
            stubDataAccessAdapter.StubList(expected);

            var actual = repository.List();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_ValidBlogPost_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);

            repository.List();

            mockDataAccessAdapter.VerifyList();
        }

        [Fact]
        public void ListByAuthorId_ValidAuthorId_ReturnsExpectedList()
        {
            var stubDataAccessAdapter = new StubIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(stubDataAccessAdapter, stubValidator);
            var expected = new List<BlogPost> { new BlogPostFactory().Create() };
            stubDataAccessAdapter.StubListByAuthorId(expected);
            var param_authorId = expected[0].AuthorId;

            var actual = repository.ListByAuthorId(param_authorId);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ListByAuthorId_ValidAuthorId_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);
            var param_authorId = new BlogPostFactory().Create().AuthorId;

            repository.ListByAuthorId(param_authorId);

            mockDataAccessAdapter.VerifyListByAuthorId(param_authorId);
        }
    }
}
