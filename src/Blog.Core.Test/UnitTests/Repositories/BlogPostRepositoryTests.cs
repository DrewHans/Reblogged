using Blog.Core.Test.Fakes;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostRepositoryTests
    {
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
        public void List_ValidBlogPost_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogPostDataAccessAdapter();
            var stubValidator = new StubIBlogPostValidator();
            var repository = new BlogPostRepository(mockDataAccessAdapter, stubValidator);

            repository.List();

            mockDataAccessAdapter.VerifyList();
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
