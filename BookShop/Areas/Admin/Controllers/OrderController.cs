using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var order = _context.Orders.Include(c => c.Customer).Include(c => c.State).OrderBy(c=>c.IdState).ToList();
                
            return View(order);
        }

        public ActionResult Info(int id)
        {
            var order = _context.Orders.Include(c => c.Customer).
                Include(c => c.Information).Include(c => c.Voucher).Include(c => c.DetailOrder).SingleOrDefault(c => c.Id == id);
            if (order == null)
                return HttpNotFound();

            return View(order);
        }

        public ActionResult Confirm(int id)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == id);
            if (order == null || order.IdState != 1)
                return HttpNotFound();
            else
            {
                order.IdState = 2;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult Delivering(int id)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == id);
            if (order == null || order.IdState != 2)
                return HttpNotFound();
            else
            {
                order.IdState = 4;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }


        public ActionResult Complete(int id)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == id);
            if (order == null || order.IdState != 4)
                return HttpNotFound();
            else
            {
                order.ReceiveDate = DateTime.Now;
                order.IdState = 5;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult Huy(int id, string reason, string other)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == id);
            if (order == null || order.IdState == 3 || order.IdState == 5)
                return HttpNotFound();
            else
            {
                order.IdState = 3;
                if (!String.IsNullOrEmpty(reason))
                    order.Reason = reason;
                else
                    order.Reason = other;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

    }
}