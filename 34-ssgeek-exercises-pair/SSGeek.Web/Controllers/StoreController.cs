using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;

namespace SSGeek.Web.Controllers
{
    public class StoreController : Controller
    {
        private IProductDAL dal;

        public StoreController(IProductDAL dal)
        {
            this.dal = dal;
        }


        public IActionResult Index()
        {
            var products = dal.GetProducts();

            return View(products);
        }
    }
}