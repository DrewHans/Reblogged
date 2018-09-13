using System;
using System.Globalization;

namespace Blog.Core.Test
{
    public class BlogPostFactory : IFactory<BlogPost>
    {
        private readonly BlogPost _blogPost;

        public BlogPostFactory()
        {
            _blogPost = new BlogPost
            {
                AuthorId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                PostBody = "A long time ago, in a galaxy far far away...",
                PostId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                PostTitle = "Star Wars: Revenge Of The Sith",
                TimeCreated = DateTime.Parse("May 19, 2005", new CultureInfo("en-us")),
                TimeLastModified = DateTime.Parse("Nov 1, 2005", new CultureInfo("en-us")),
            };
        }

        public BlogPost Create()
        {
            return _blogPost;
        }

        public BlogPostFactory StubAuthorId(Guid id)
        {
            _blogPost.AuthorId = id;
            return this;
        }

        public BlogPostFactory StubPostId(Guid id)
        {
            _blogPost.PostId = id;
            return this;
        }
    }
}
