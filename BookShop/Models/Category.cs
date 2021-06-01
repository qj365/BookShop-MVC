namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thể loại.")]
        [StringLength(50)]
        [Display(Name = "Thể loại")]
        public string Name { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
