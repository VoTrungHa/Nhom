namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatHang")]
    public partial class MatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MatHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            Contents = new HashSet<Content>();
        }

        [Key]
        public long MaMH { get; set; }

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

        public bool? status { get; set; }

        [StringLength(50)]
        public string ManHinh { get; set; }

        [StringLength(50)]
        public string Ram { get; set; }

        [StringLength(50)]
        public string CameraT { get; set; }

        [StringLength(50)]
        public string CameraS { get; set; }

        [StringLength(150)]
        public string Cpu { get; set; }

        [StringLength(150)]
        public string Gpu { get; set; }

        [StringLength(150)]
        public string BoNho { get; set; }

        [StringLength(50)]
        public string DungLuongPin { get; set; }

        public int? luotXem { get; set; }

        [StringLength(50)]
        public string link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }

        public virtual LoaiMatHang LoaiMatHang { get; set; }
    }
}
