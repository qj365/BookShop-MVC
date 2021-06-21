using BookShop.Models;
using System.Linq;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {

        private ApplicationDbContext _context;

        public AuthorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Author
        public ActionResult Index()
        {
            var author = _context.Authors.ToList();
            return View(author);
        }

        public JsonResult IsExist(string Name)
        { 
            return Json(!_context.Authors.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
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