using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Blog.Core
{
    public class FileDatabase<T> : IFileDatabase<T>
    {
        private readonly IFileDatabaseReader _fileDatabaseReader;
        private readonly IFileDatabaseWriter _fileDatabaseWriter;

        public FileDatabase(IFileDatabaseReader fileDatabaseReader,
            IFileDatabaseWriter fileDatabaseWriter)
        {
            _fileDatabaseReader = fileDatabaseReader;
            _fileDatabaseWriter = fileDatabaseWriter;
        }

        public List<T> ReadDatabase(string filePath)
        {
            var fileContents = _fileDatabaseReader.Read(filePath);
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
            _fileDatabaseWriter.Write(filePath, appendToFile, value);
        }
    }
}