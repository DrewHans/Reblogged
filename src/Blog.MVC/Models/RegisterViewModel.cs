using System.ComponentModel.DataAnnotations;

namespace Blog.MVC
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
    }
}
