namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public Book()
        {
            DetailOrder = new HashSet<DetailOrder>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double? Discount { get; set; }

        public int? Price { get; set; }

        public int? Amount { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        public string Description { get; set; }

        public int? IdPublisher { get; set; }
        [ForeignKey("IdPublisher")]
        public virtual Publisher Publisher { get; set; }

        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }

        public int? IdAuthor { get; set; }
        [ForeignKey("IdAuthor")]

        public virtual Author Author { get; set; }

        public virtual ICollection<DetailOrder> DetailOrder { get; set; }
    }
}
