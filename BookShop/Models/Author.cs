namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Author")]
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập tên tác giả.")]
        [StringLength(50)]
        [Display(Name="Tên tác giả")]
        [Remote("IsExist", "Author", ErrorMessage = "{0} đã tồn tại")]
        public string Name { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
