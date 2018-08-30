using System.Collections.Generic;

namespace Blog.Core
{
    public interface IFileDatabase<T>
    {
        void ClearDatabase(string filePath);
        void OverwriteDatabase(string filePath, List<T> listOfEntity);
        List<T> ReadDatabase(string filePath);
        void WriteToDatabase(string filePath, List<T> listOfEntity);
        void WriteToDatabase(string filePath, T entity);
    }
}