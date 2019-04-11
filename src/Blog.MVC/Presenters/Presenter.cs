using Microsoft.AspNetCore.Mvc;
using System;

namespace Blog.MVC
{
    public abstract class Presenter : Controller
    {
        public IActionResult PageForException(Exception e)
        {
            return StatusCode(500);
        }
    }
}
