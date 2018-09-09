using System;
using System.IO;

namespace Blog.Core
{
    public class FileReader : IFileReader
    {
        public string Read(string filepath)
        {
            try
            {
                return ReadFile(filepath);
            }
            catch (Exception e)
            {
                throw new DataAccessException(e);
            }
        }

        private string ReadFile(string filepath)
        {
            using (var reader = new StreamReader(new FileStream(filepath, FileMode.OpenOrCreate)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}