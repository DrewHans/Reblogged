using System;

namespace Blog.Core
{
    public interface IBlogPostValidator
    {
        bool IsValidBlogPost(BlogPost blogPost);
        bool IsValidAuthorId(Guid authorId);
        bool IsValidPostBody(string postBody);
        bool IsValidPostId(Guid postId);
        bool IsValidPostTitle(string postTitle);
        bool IsValidTimeCreated(DateTime timeCreated);
        bool IsValidTimeLastModified(DateTime timeLastModified);
    }
}