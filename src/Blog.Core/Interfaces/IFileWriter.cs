namespace Blog.Core
{
    public interface IFileWriter
    {
        void Write(string filepath, bool appendToFile, string value);
    }
}