using System;

namespace Blog.Core
{
    public class DataAccessException : Exception
    {
        public DataAccessException(Exception e)
            : base($"{e.GetType().Name} thrown", e)
        { }
    }
}