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
        [HttpGet]
        public IActionResult Index()
        {
            var dal = new ForumPostSqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=SSGeek;Integrated Security=True");
            var posts = dal.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(ForumPostModel post)
        {
            var dal = new ForumPostSqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=SSGeek;Integrated Security=True");
            var didPost=dal.SaveNewPost(post);
            if (didPost)
            {
                return RedirectToAction("index", "forum");

            }
            else
            {
                return Forbid();
            }
        }
    }
}