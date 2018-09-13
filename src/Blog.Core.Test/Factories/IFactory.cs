namespace Blog.Core.Test
{
    public interface IFactory<T>
    {
        T Create();
    }
}