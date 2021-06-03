namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(50)]
        public string RefLink { get; set; }

        public int? Stt { get; set; }
    }
}
