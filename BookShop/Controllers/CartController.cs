using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;
using BookShop.Entities;
using System.Web.Script.Serialization;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();

        private const string CartSession = "CartSession";

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartViewModels>();
            if (cart != null)
            {
                list = (List<CartViewModels>)cart;
            }
            return View(list);
        }

        public ActionResult Add(int id, int amount)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartViewModels>)cart;
                if (list.Exists(x => x.Book.Id==id))
                {
                    foreach (var item in list)
                    {
                        if (item.Book.Id == id)
                        {
                            item.amount += amount;
                        }
                    }
                }
                else
                {
                    var item = new CartViewModels();
                    item.Book = _context.Books.Find(id);
                    item.amount = amount;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartViewModels();
                item.Book = _context.Books.Find(id);
                item.amount = amount;
                var list = new List<CartViewModels>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartViewModels>>(cartModel);
            var sessionCart = (List<CartViewModels>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x=>x.Book.Id==item.Book.Id);
                if (jsonItem != null)
                {
                    if (jsonItem.amount <= 0)
                    {
                        sessionCart.RemoveAll(x=>x.Book.Id==jsonItem.Book.Id);
                    }
                    item.amount = jsonItem.amount;
                }
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartViewModels>)Session[CartSession];
            sessionCart.RemoveAll(x=>x.Book.Id==id);
            Session[CartSession] = sessionCart;
            return Json(new {
                status = true
                });
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}