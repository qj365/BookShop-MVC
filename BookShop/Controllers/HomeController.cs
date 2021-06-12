using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = _context.Banners;
            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderBanner()
        {
            var model = _context.Banners;
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderCategory()
        {
            var model = _context.Categories;
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult RenderBestSeller()
        {
            var model = _context.Books.OrderBy(book => book.DetailOrder.Count);
            return PartialView(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}