namespace Blog.Core
{
    public interface IFileDatabaseReader
    {
        string Read(string filepath);
    }
}