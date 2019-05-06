using Blog.Core;
using Blog.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Blog.MVC.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly IListRecentBlogPostsInteractor _listRecentBlogPostsInteractor;

        public BlogController(IListRecentBlogPostsInteractor listRecentBlogPostsInteractor)
        {
            _listRecentBlogPostsInteractor = listRecentBlogPostsInteractor;
        }

        [HttpGet] // displays blog landing page
        public IActionResult Index()
        {
            var request = new ListRecentBlogPostsRequest();
            var response = _listRecentBlogPostsInteractor.ListRecentBlogPosts(request);
            var viewmodel = new BlogIndexViewModel();
            if (response.RequestSuccessful)
            {
                viewmodel.RecentPosts = MapListOfBlogPostToListOfDTOModel(response.ListOfRecentPosts);
            }
            return View(viewmodel);
        }

        [HttpGet("posts/add")] // displays page for creating a new post
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpGet("posts/edit")] // displays page for editing an existing post
        public IActionResult EditPost()
        {
            return View();
        }

        [HttpGet("posts/{post_id}")] // displays page for a specific post
        public IActionResult GetPost(Guid post_id)
        {
            return View();
        }

        [HttpGet("users/{user_id}")] // displays page for a specific user
        public IActionResult GetUser(Guid user_id)
        {
            return View();
        }

        [HttpGet("posts")] // displays page with a list of all posts
        public IActionResult ListPosts()
        {
            return View();
        }

        [HttpGet("users")] // displays page with a list of all users
        public IActionResult ListUsers()
        {
            return View();
        }

        [HttpPost("posts")] // creates a new post or redirects to AddPost page
        public IActionResult CreatePost(Guid author_id, string post_title, string post_body)
        {
            return View();
        }

        [HttpDelete("posts/{post_id}")] // removes a specific post or redirects to EditPost page
        public IActionResult RemovePost(Guid post_id)
        {
            return View();
        }

        [HttpPatch("posts/{post_id}")] // partially updates a specific post or redirects to EditPost page
        public IActionResult UpdatePost(Guid post_id, Guid author_id, string post_title, string post_body)
        {
            return View();
        }

        private BlogPostDTOModel MapBlogPostToDTOModel(BlogPost post)
        {
            var dto = new BlogPostDTOModel();
            dto.AuthorId = post.AuthorId;
            dto.PostBody = post.PostBody;
            dto.PostId = post.PostId;
            dto.PostTitle = post.PostTitle;
            dto.TimeCreated = post.TimeCreated;
            dto.TimeLastModified = post.TimeLastModified;
            return dto;
        }

        private BlogPost MapDTOModelToBlogPost(BlogPostDTOModel dto)
        {
            var post = new BlogPost();
            post.AuthorId = dto.AuthorId;
            post.PostBody = dto.PostBody;
            post.PostId = dto.PostId;
            post.PostTitle = dto.PostTitle;
            post.TimeCreated = dto.TimeCreated;
            post.TimeLastModified = dto.TimeLastModified;
            return post;
        }

        private List<BlogPostDTOModel> MapListOfBlogPostToListOfDTOModel(List<BlogPost> list)
        {
            var newList = new List<BlogPostDTOModel>();
            foreach (var item in list)
            {
                newList.Add(MapBlogPostToDTOModel(item));
            }
            return newList;
        }

        private List<BlogPost> MapListOfDTOModelToListOfBlogPost(List<BlogPostDTOModel> list)
        {
            var newList = new List<BlogPost>();
            foreach (var item in list)
            {
                newList.Add(MapDTOModelToBlogPost(item));
            }
            return newList;
        }
    }
}
