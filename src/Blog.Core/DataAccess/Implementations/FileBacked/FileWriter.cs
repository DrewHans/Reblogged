using System;
using System.IO;

namespace Blog.Core
{
    public class FileWriter : IFileWriter
    {
        public void Write(string filepath, bool appendToFile, string value)
        {
            try
            {
                WriteFile(filepath, appendToFile, value);
            }
            catch (Exception e)
            {
                throw new DataAccessException(e);
            }
        }

        public void WriteFile(string filepath, bool appendToFile, string value)
        {
            using (var writer = new StreamWriter(filepath, appendToFile))
            {
                writer.Write(value);
            }
        }
    }
}