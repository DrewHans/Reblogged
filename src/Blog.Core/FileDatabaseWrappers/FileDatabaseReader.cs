using System;
using System.IO;

namespace Blog.Core
{
    public class FileDatabaseReader : IFileDatabaseReader
    {
        public string Read(string filepath)
        {
            using (var reader = new StreamReader(new FileStream(filepath, FileMode.OpenOrCreate)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}