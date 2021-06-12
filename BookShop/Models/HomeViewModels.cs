using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class HomeViewModels
    {
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}