using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BookShop.Areas.Admin.ViewModel;
using System.IO;

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
            var book = _context.Books
                .Include(c => c.Author)
                .Include(c => c.Category)
                .Include(c => c.Publisher)
                .ToList();
            return View(book);
        }

        public ActionResult test()
        {
            return View();
        }
        public ViewResult Create()
        {
            var author = _context.Authors.ToList();
            var category = _context.Categories.ToList();
            var publisher = _context.Publishers.ToList();
            var viewModel = new BookViewModel
            {
                Authors = author,
                Categories = category,
                Publishers = publisher
            };
            return View("BookForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if (book == null)
                return HttpNotFound();
            var author = _context.Authors.ToList();
            var category = _context.Categories.ToList();
            var publisher = _context.Publishers.ToList();
            var viewModel = new BookViewModel(book)
            {
                Authors = author,
                Categories = category,
                Publishers = publisher
            };
            return View("BookForm", viewModel);
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
        public ActionResult Save(Book book, HttpPostedFileBase photo)
        {
            if (book.Id == 0)
            {
                if (photo != null && photo.ContentLength > 0)
                { 
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BookImage/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    book.Photo = photo.FileName;             
                }
                else
                    book.Photo = "150x200.png";
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(c => c.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.Discount = book.Discount;
                bookInDb.Price = book.Price;
                bookInDb.Amount = book.Amount;
                bookInDb.Description = book.Description;
                bookInDb.IdAuthor= book.IdAuthor;
                bookInDb.IdCategory = book.IdCategory;
                bookInDb.IdPublisher = book.IdPublisher;
                bookInDb.Price = book.Price;
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BookImage/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    bookInDb.Photo = photo.FileName;
                }
                
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Book");
        }
    }
}