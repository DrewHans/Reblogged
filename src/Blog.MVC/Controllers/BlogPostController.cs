using Blog.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blog.MVC.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class BlogPostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BlogPostViewModel viewmodel)
        {
            return View();
            // if response successful:
            //     context = new {post_id=viewmodel.PostId}
            //     return RedirectToAction("Get", "BlogPost", context)
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(BlogPostViewModel viewmodel)
        {
            return View();
            // if response successful:
            //     context = new {post_id=viewmodel.PostId}
            //     return RedirectToAction("Get", "BlogPost", context)
        }

        [HttpGet]
        public IActionResult Get(string post_id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(string author_id)
        {
            return View();
        }
    }
}
