using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class ForumController : Controller
    {
        private IForumDAL dal;

        public ForumController(IForumDAL dal)
        {
            this.dal = dal;
        }

        // 1.  We need to make our Index View first so that visitors can view their Space Posts
        [HttpGet]
        public IActionResult Index()
        {
            // 2.  Create our Forum DAL with a connection string to the database
            var posts = dal.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }

        // This is called immediately after submitting the form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(ForumPostModel post)
        {
            if (ModelState.IsValid)
            {
                var didPost = dal.SaveNewPost(post);
                if (didPost)
                {
                    TempData["Show_Message"] = true;
                    return RedirectToAction("index", "forum");
                }
                else
                {
                    return Forbid();
                }
            }

            return View(post);
            // If we made a post, direct them to the forum where they can view messages

        }
    }
}