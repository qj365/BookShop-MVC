namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Information
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Information()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên người nhận.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhận.")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại nhận.")]
        [StringLength(10)]
        public string Sdt { get; set; }

        public bool? Defaults { get; set; }

        public int? IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public virtual Customer Customer { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
