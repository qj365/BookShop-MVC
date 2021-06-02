using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var book = _context.Books.ToList();
            return View(book);
        }

        public ViewResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();
            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return RedirectToAction("Index", "book");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                if (book.Id == 0)
                    return View("create", book);
                else
                    return View("Edit", book);
            }
            if (book.Id == 0)
                _context.Books.Add(book);
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.Discount = book.Discount;
                
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "book");
        }
    }
}