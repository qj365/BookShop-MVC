﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}