namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Infomation = new HashSet<Information>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Sdt { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        [StringLength(4)]
        public string Gender { get; set; }

        public virtual ICollection<Information> Infomation { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
