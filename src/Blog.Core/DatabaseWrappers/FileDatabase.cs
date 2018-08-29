using Newtonsoft.Json;
using System.Collections.Generic;

namespace Blog.Core
{
    public class FileDatabase<T> : IFileDatabase<T>
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public FileDatabase(IFileReader fileReader, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public List<T> ReadDatabase(string filePath)
        {
            var fileContents = _fileReader.Read(filePath);
            if (fileContents == null)
                return new List<T>();
            var listOfT = JsonConvert.DeserializeObject<List<T>>(fileContents);
            return (listOfT == null) ? new List<T>() : listOfT;
        }

        public void WriteDatabase(string filePath, bool appendToFile, List<T> listOfT)
        {
            if (listOfT == null || listOfT.Count == 0)
                return;
            var value = JsonConvert.SerializeObject(listOfT);
            _fileWriter.Write(filePath, appendToFile, value);
        }
    }
}