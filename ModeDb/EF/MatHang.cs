namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
            DanhGias = new HashSet<DanhGia>();
        }

        [Key]
        public long MaMH { get; set; }

        [Required(ErrorMessage="Nhập Tên Sản Phẩm")]
        [DisplayName("Tên Mặt Hàng")]
        [StringLength(100)]
        public string TenMh { get; set; }
        [Required(ErrorMessage = "Nhập Giá Chính")]
        [DisplayName("Giá Chính")]
        public decimal? GiaThanh { get; set; }
        [Required(ErrorMessage = "Nhập Giá khuyến Mãi")]
        [DisplayName("Giá khuyến Mãi")]
        public decimal? GiaKhuyenMai { get; set; }
        [Required(ErrorMessage = "Nhập Số Lượng")]
        [DisplayName("Số Lượng")]
        public int? Soluong { get; set; }
        [Required(ErrorMessage = "Chọn Loại Hàng")]
        [DisplayName("Mã Loại Hàng")]
        [StringLength(50)]
        public string MaLoaiHang { get; set; }
        [Required(ErrorMessage = "Ngày Nhập Còn Trống")]
        [DisplayName("Ngày Nhập ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySuaDoi { get; set; }

        [StringLength(150)]
        public string Image { get; set; }

        public bool? status { get; set; }
        [Required(ErrorMessage = "Nhập Màn Hình")]
        [DisplayName("Màn Hình")]
        [StringLength(50)]
        public string ManHinh { get; set; }
        [Required(ErrorMessage = "Nhập Ram")]
        [DisplayName("Ram")]
        [StringLength(50)]
        public string Ram { get; set; }
        [Required(ErrorMessage = "Nhập Camera Trước")]
        [DisplayName("Camera Trước")]
        [StringLength(50)]
        public string CameraT { get; set; }
        [Required(ErrorMessage = "Nhập Camera Sau")]
        [DisplayName("Camera Sau")]
        [StringLength(50)]
        public string CameraS { get; set; }
        [Required(ErrorMessage = "Nhập CPU")]
        [DisplayName("CPU")]
        [StringLength(150)]
        public string Cpu { get; set; }
        [Required(ErrorMessage = "Nhập GPU")]
        [DisplayName("GPU")]
        [StringLength(150)]
        public string Gpu { get; set; }
        [Required(ErrorMessage = "Nhập Bộ Nhớ")]
        [DisplayName("Bộ Nhớ")]
        [StringLength(150)]
        public string BoNho { get; set; }
        [Required(ErrorMessage = "Nhập Dung Lượng Pin")]
        [DisplayName("Dung Lượng Pin")]
        [StringLength(50)]
        public string DungLuongPin { get; set; }

        public int? luotXem { get; set; }
        [Required(ErrorMessage = "Chọn Hệ Điều Hàn")]
        [DisplayName("Hệ Điều hành")]
        [StringLength(50)]
        public string MaHDH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        public virtual HeDieuHanh HeDieuHanh { get; set; }

        public virtual LoaiMatHang LoaiMatHang { get; set; }
    }
}
