using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.MVC
{
    public class BlogUserViewModel
    {
        public List<string> Permissions { get; set; } = new List<string>();

        public DateTime TimeRegistered { get; set; }

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
    }
}
