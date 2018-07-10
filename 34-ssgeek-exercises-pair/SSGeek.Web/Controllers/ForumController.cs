using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;

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
    }
}