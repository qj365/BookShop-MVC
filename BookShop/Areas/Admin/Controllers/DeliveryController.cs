using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    public class DeliveryController : Controller
    {
        private ApplicationDbContext _context;

        public DeliveryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var order = _context.Orders.Include(c => c.Customer);
            return View();
        }
    }
}