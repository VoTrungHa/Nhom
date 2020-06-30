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

        [DisplayName("Tên Sản Phẩm")]
        [Required(ErrorMessage = "Tên Thành Trống")]
        [StringLength(100)]
        public string TenMh { get; set; }

        [DisplayName("Giá Thành")]
        [Required(ErrorMessage = "Giá Thành Trống")]
        [DisplayFormat(DataFormatString = "{0:#,##0}", ApplyFormatInEditMode = true)]
        public decimal? GiaThanh { get; set; }

        [DisplayName("Giá Khuyến Mãi")]
        [Required(ErrorMessage = "Giá Thành Trống")]
        [DisplayFormat(DataFormatString = "{0:#,##0}", ApplyFormatInEditMode = true)]
        public decimal? GiaKhuyenMai { get; set; }


        [DisplayName("Số Lượng")]
        [Required(ErrorMessage = "Số Lượng Thành Trống")]
        public int? Soluong { get; set; }

        [DisplayName("Loại Hàng")]
        [Required(ErrorMessage = "Loại Hàng Trống")]
        [StringLength(50)]
        public string MaLoaiHang { get; set; }
        [Required(ErrorMessage = "Ngày Nhập Còn Trống")]
        [DisplayName("Ngày Nhập ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
         
        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }



        [DisplayName("Ngày Sửa ")]
        [Column(TypeName = "date")]
        public DateTime? NgaySuaDoi { get; set; }


        [StringLength(150)]
        public string Image { get; set; }

        public bool? status { get; set; }

        [DisplayName("Màn Hình")]
        [Required(ErrorMessage = "Màn Hình Trống")]
        [StringLength(50)]
        public string ManHinh { get; set; }

        [DisplayName("RAM")]
        [Required(ErrorMessage = "RAM Trống")]
        [StringLength(50)]
        public string Ram { get; set; }

        [DisplayName("Camera")]
        [Required(ErrorMessage = "Camera Trống")]
        [StringLength(50)]
        public string CameraT { get; set; }

        [DisplayName("Camera")]
        [Required(ErrorMessage = "Camera Trống")]
        [StringLength(50)]
        public string CameraS { get; set; }

        [DisplayName("C P U")]
        [Required(ErrorMessage = "C P U Trống")]
        [StringLength(150)]
        public string Cpu { get; set; }

        [DisplayName("G P U")]
        [Required(ErrorMessage = "G P U Trống")]
        [StringLength(150)]
        public string Gpu { get; set; }

        [DisplayName("Bộ Nhớ")]
        [Required(ErrorMessage = " Bộ Nhớ Trống")]
        [StringLength(150)]
        public string BoNho { get; set; }

        [DisplayName("Dung Lượng Pin")]
        [Required(ErrorMessage = "Lượng Pin Trống")]
        [StringLength(50)]
        public string DungLuongPin { get; set; }

        public int? luotXem { get; set; }

        [DisplayName("Hệ Điều Hành")]
        [Required(ErrorMessage = "Hệ Điều Hành Trống")]
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
