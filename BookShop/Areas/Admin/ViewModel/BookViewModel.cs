using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.Areas.Admin.ViewModel
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
    }
}