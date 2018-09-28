using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.MVC
{
    public class BlogPostViewModel
    {
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "Post Body is required")]
        public string PostBody { get; set; }

        public Guid PostId { get; set; }

        [Required(ErrorMessage = "Post Title is required")]
        public string PostTitle { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime TimeLastModified { get; set; }
    }
}
