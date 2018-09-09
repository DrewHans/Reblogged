namespace Blog.Core
{
    public interface IBlogPostValidator
    {
        void ValidateBlogPost(BlogPost blogPost);
    }
}