using System.ComponentModel.DataAnnotations;

namespace Blog.MVC
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }
    }
}
