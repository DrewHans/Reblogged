using Blog.Core;
using Blog.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.MVC.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [Route("blog")]
    public class BlogController : Controller
    {
        private readonly IAddBlogPostInteractor _addBlogPostInteractor;
        private readonly IEditBlogPostInteractor _editBlogPostInteractor;
        private readonly IGetBlogPostInteractor _getBlogPostInteractor;
        private readonly IListBlogPostsInteractor _listBlogPostsInteractor;
        private readonly IListBlogUsersInteractor _listBlogUsersInteractor;
        private readonly IListRecentBlogPostsInteractor _listRecentBlogPostsInteractor;

        public BlogController(IAddBlogPostInteractor addBlogPostInteractor,
            IEditBlogPostInteractor editBlogPostInteractor,
            IGetBlogPostInteractor getBlogPostInteractor,
            IListBlogPostsInteractor listBlogPostsInteractor,
            IListBlogUsersInteractor listBlogUsersInteractor,
            IListRecentBlogPostsInteractor listRecentBlogPostsInteractor)
        {
            _addBlogPostInteractor = addBlogPostInteractor;
            _editBlogPostInteractor = editBlogPostInteractor;
            _getBlogPostInteractor = getBlogPostInteractor;
            _listBlogPostsInteractor = listBlogPostsInteractor;
            _listBlogUsersInteractor = listBlogUsersInteractor;
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

        [HttpGet("posts/{id}")] // displays page for a specific post
        public IActionResult GetPost(string id)
        {
            var postid = Guid.Parse(id);
            var request = new GetBlogPostRequest { PostId = postid };
            var response = _getBlogPostInteractor.GetBlogPost(request);
            var viewmodel = new BlogGetPostViewModel();
            if (response.RequestSuccessful)
            {
                viewmodel.Post = MapBlogPostToDTOModel(response.Post);
                viewmodel.User = MapBlogUserToDTOModel(response.User);
            }
            return View(viewmodel);
        }

        [HttpGet("users/{id}")] // displays page for a specific user
        public IActionResult GetUser(string id)
        {
            var userid = Guid.Parse(id);
            //TODO: implement GetUser like GetPost method above
            return View();
        }

        [HttpGet("posts")] // displays page with a list of all posts
        public IActionResult ListPosts()
        {
            var request = new ListBlogPostsRequest();
            var response = _listBlogPostsInteractor.ListBlogPosts(request);
            var viewmodel = new BlogListPostsViewModel();
            if (response.RequestSuccessful)
            {
                viewmodel.ListOfPosts = MapListOfBlogPostToListOfDTOModel(response.ListOfPosts);
            }
            return View(viewmodel);
        }

        [HttpGet("users")] // displays page with a list of all users
        public IActionResult ListUsers()
        {
            var request = new ListBlogUsersRequest();
            var response = _listBlogUsersInteractor.ListBlogUsers(request);
            var viewmodel = new BlogListUsersViewModel();
            if (response.RequestSuccessful)
            {
                viewmodel.ListOfUsers = MapListOfBlogUserToListOfDTOModel(response.ListOfUsers);
            }
            return View(viewmodel);
        }

        [HttpPost("posts")] // creates a new post or redirects to AddPost page
        public IActionResult CreatePost(BlogPostDTOModel dto)
        {
            if (ModelState.IsValid == false)
                return RedirectToAction("AddPost", "Blog", dto);

            var userId = User.Claims.FirstOrDefault(c => c.Type == "BlogUserId").Value;
            var request = new AddBlogPostRequest
            {
                AuthorId = Guid.Parse(userId),
                PostBody = dto.PostBody,
                PostTitle = dto.PostTitle
            };
            var response = _addBlogPostInteractor.AddBlogPost(request);
            if (response.AddSuccessful)
                return RedirectToAction("GetPost", "Blog", new { post_id = response.Post.PostId });
            return RedirectToAction("AddPost", "Blog", dto);
        }

        [HttpDelete("posts/{post_id}")] // removes a specific post or redirects to EditPost page
        public IActionResult RemovePost(Guid post_id)
        {
            return View();
        }

        [HttpPatch("posts/{post_id}")] // partially updates a specific post or redirects to EditPost page
        public IActionResult UpdatePost(Guid post_id, BlogPostDTOModel dto)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "BlogUserId").Value);
            if (ModelState.IsValid == false || userId != dto.AuthorId)
                return RedirectToAction("EditPost", "Blog", dto);

            var request = new EditBlogPostRequest
            {
                PostBody = dto.PostBody,
                PostId = dto.PostId,
                PostTitle = dto.PostTitle
            };
            var response = _editBlogPostInteractor.EditBlogPost(request);
            if (response.EditSuccessful)
                return RedirectToAction("GetPost", "Blog", new { post_id = response.Post.PostId });
            return RedirectToAction("EditPost", "Blog", dto);
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

        private BlogUserDTOModel MapBlogUserToDTOModel(BlogUser user)
        {
            var dto = new BlogUserDTOModel();
            dto.Permissions = user.Permissions;
            dto.TimeRegistered = user.TimeRegistered;
            dto.UserId = user.UserId;
            dto.UserName = user.UserName;
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

        private BlogUser MapDTOModelToBlogUser(BlogUserDTOModel dto)
        {
            var user = new BlogUser();
            user.Permissions = dto.Permissions;
            user.TimeRegistered = dto.TimeRegistered;
            user.UserId = dto.UserId;
            user.UserName = dto.UserName;
            return user;
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

        private List<BlogUserDTOModel> MapListOfBlogUserToListOfDTOModel(List<BlogUser> list)
        {
            var newList = new List<BlogUserDTOModel>();
            foreach (var item in list)
            {
                newList.Add(MapBlogUserToDTOModel(item));
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

        private List<BlogUser> MapListOfDTOModelToListOfBlogUser(List<BlogUserDTOModel> list)
        {
            var newList = new List<BlogUser>();
            foreach (var item in list)
            {
                newList.Add(MapDTOModelToBlogUser(item));
            }
            return newList;
        }
    }
}
