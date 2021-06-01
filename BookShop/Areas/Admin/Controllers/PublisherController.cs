using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class PublisherController : Controller
    {
        private ApplicationDbContext _context;

        public PublisherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var author = _context.Authors.ToList();
            return View(author);
        }

        public ViewResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var author = _context.Authors.SingleOrDefault(c => c.Id == id);
            if (author == null)
                return HttpNotFound();
            return View(author);
        }

        public ActionResult Delete(int id)
        {
            var author = _context.Authors.SingleOrDefault(c => c.Id == id);
            if (author == null)
                return HttpNotFound();
            else
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
                return RedirectToAction("Index", "Author");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Author author)
        {
            if (!ModelState.IsValid)
            {
                if (author.Id == 0)
                    return View("create", author);
                else
                    return View("Edit", author);
            }
            if (author.Id == 0)
                _context.Authors.Add(author);
            else
            {
                var authorInDb = _context.Authors.Single(c => c.Id == author.Id);
                authorInDb.Name = author.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Author");
        }
    }
}