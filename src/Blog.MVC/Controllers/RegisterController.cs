using Blog.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterUserInteractor _registerUserInteractor;

        public RegisterController(IRegisterUserInteractor registerUserInteractor)
        {
            _registerUserInteractor = registerUserInteractor;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel viewmodel)
        {
            if (ModelState.IsValid == false)
                return RedirectToAction("Index", "Register");
            var request = new RegisterUserRequest { UserName = viewmodel.UserName };
            var response = _registerUserInteractor.RegisterUser(request);
            if (response.RegisterSuccessful)
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Register");
        }
    }
}
