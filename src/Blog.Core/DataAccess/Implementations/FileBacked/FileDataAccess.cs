using Newtonsoft.Json;
using System.Collections.Generic;

namespace Blog.Core
{
    public class FileDataAccess<T> : IFileDataAccess<T>
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public FileDataAccess(IFileReader fileReader, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public void ClearDatabase(string filePath)
        {
            var appendToFile = false;
            var value = "";
            _fileWriter.Write(filePath, appendToFile, value);
        }

        public void OverwriteDatabase(string filePath, List<T> listOfEntity)
        {
            if (listOfEntity == null || listOfEntity.Count == 0)
                return;
            var appendToFile = false;
            var value = JsonConvert.SerializeObject(listOfEntity);
            _fileWriter.Write(filePath, appendToFile, value);
        }

        public List<T> ReadDatabase(string filePath)
        {
            var fileContents = _fileReader.Read(filePath);
            if (fileContents == null)
                return new List<T>();
            var list = JsonConvert.DeserializeObject<List<T>>(fileContents);
            return (list == null) ? new List<T>() : list;
        }

        public void WriteToDatabase(string filePath, List<T> listOfEntity)
        {
            if (listOfEntity == null || listOfEntity.Count == 0)
                return;
            var list = ReadDatabase(filePath);
            list.AddRange(listOfEntity);
            OverwriteDatabase(filePath, list);
        }

        public void WriteToDatabase(string filePath, T entity)
        {
            if (entity == null)
                return;
            var list = ReadDatabase(filePath);
            list.Add(entity);
            OverwriteDatabase(filePath, list);
        }
    }
}