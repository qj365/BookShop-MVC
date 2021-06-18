using BookShop.Models;
using System.Linq;

namespace BookShop.Areas.Admin.Dao
{
    public class DeliveryDAO
    {
        private ApplicationDbContext _context;

        public DeliveryDAO()
        {
            _context = new ApplicationDbContext();
        }
        public int CountTH(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var order = customer.Orders.Where(c => c.IdState == 3).Count();
            return order;
        }

        public Book GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            return book;
        }

        public int? tongTien(int idOrder)
        {
            return _context.DetailOrders.Where(c => c.IdOrder == idOrder).Sum(c => c.Price);
        }
    }
}