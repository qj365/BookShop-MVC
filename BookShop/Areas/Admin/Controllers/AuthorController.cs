using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {

        private ApplicationDbContext _context;

        public AuthorController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/Author
        public ActionResult Index()
        {
            var author = _context.Authors.ToList();
            return View(author);
        }

        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index","Author");
        }
    }
}