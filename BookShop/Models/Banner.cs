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

        [StringLength(255)]
        [Display(Name = "Ảnh")]
        public string Photo { get; set; }

        [StringLength(10)]
        [Display(Name = "Trạng thái")]
        public string State { get; set; }

        [StringLength(255)]
        [Display(Name = "Đường dẫn")]
        public string RefLink { get; set; }

        [Display(Name = "Số thứ tự")]
        //[Range(1, int.MaxValue, ErrorMessage = "{0} phải có giá trị lớn hơn 0. (Đặt đầu tiên STT 1)")]
        public int? Stt { get; set; }
    }
}
