namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        [Key]
        public long MaND { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string NoiDung { get; set; }

        [StringLength(100)]
        public string TenMh { get; set; }

        public decimal? GiaThanh { get; set; }

        public int? Soluong { get; set; }

        [StringLength(50)]
        public string MaLoaiHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySuaDoi { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        public long MaMH { get; set; }

        public virtual LoaiMatHang LoaiMatHang { get; set; }

        public virtual MatHang MatHang { get; set; }
    }
}
