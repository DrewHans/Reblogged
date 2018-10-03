using Blog.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Blog.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginUserInteractor _loginUserInteractor;

        public LoginController(ILoginUserInteractor loginUserInteractor)
        {
            _loginUserInteractor = loginUserInteractor;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel viewmodel)
        {
            if (ModelState.IsValid == false)
                return RedirectToAction("Index", "Login");
            var request = new LoginUserRequest { UserName = viewmodel.UserName };
            var response = _loginUserInteractor.LoginUser(request);
            if (response.SystemLoginSuccessful)
            {
                PerformClientSignIn(response.User);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Logout()
        {
            PerformClientSignOut();
            return RedirectToAction("Index", "Login");
        }

        private List<Claim> BuildListOfUserClaims(BlogUser bloguser)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("BlogUserId", bloguser.UserId.ToString()));
            foreach (var permission in bloguser.Permissions)
                claims.Add(new Claim(ClaimTypes.Role, permission));
            return claims;
        }

        private void PerformClientSignIn(BlogUser bloguser)
        {
            var claims = BuildListOfUserClaims(bloguser);
            var authProperties = new AuthenticationProperties();
            var authType = CookieAuthenticationDefaults.AuthenticationScheme;
            var claimsIdentity = new ClaimsIdentity(claims, authType);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(authType, claimsPrincipal, authProperties);
        }

        private void PerformClientSignOut()
        {
            HttpContext.SignOutAsync();
        }
    }
}
