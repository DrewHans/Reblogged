namespace Blog.Core
{
    public interface IFileDatabaseWriter
    {
        void Write(string filepath, bool appendToFile, string value);
    }
}