using System.Collections.Generic;

namespace Blog.Core
{
    public interface IFileDatabase<T>
    {
        List<T> ReadDatabase(string filePath);
        void WriteDatabase(string filePath, bool appendToFile, List<T> listOfT);
    }
}