﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSGeek.Web.Controllers
{
    public class TriviaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}