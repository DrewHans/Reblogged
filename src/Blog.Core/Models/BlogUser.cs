using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogUser
    {
        public List<string> Permissions { get; set; } = new List<string>();
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}