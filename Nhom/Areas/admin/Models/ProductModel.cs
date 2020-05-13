using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nhom.Areas.admin.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Chưa nhập Tên mặt Hàng")]
        [StringLength(100)]
        public string TenMh { get; set; }
        [Required(ErrorMessage = "Chưa nhập Giá thành")]
        public decimal? GiaThanh { get; set; }

        public decimal? GiaKhuyenMai { get; set; }
        [Required(ErrorMessage = "Chưa nhập số lượng")]
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
        [Required(ErrorMessage = "Chưa nhập Màn Hình")]
        [StringLength(50)]
        public string ManHinh { get; set; }
        [Required(ErrorMessage = "Chưa nhập Ram")]
        [StringLength(50)]
        public string Ram { get; set; }
        [Required(ErrorMessage = "Chưa nhập Camera trước")]
        [StringLength(50)]
        public string CameraT { get; set; }
        [Required(ErrorMessage = "Chưa nhập Camera sau")]
        [StringLength(50)]
        public string CameraS { get; set; }
        [Required(ErrorMessage = "Chưa nhập CPU")]
        [StringLength(150)]
        public string Cpu { get; set; }
        [Required(ErrorMessage = "Chưa nhập GPU")]
        [StringLength(150)]
        public string Gpu { get; set; }
        [Required(ErrorMessage = "Chưa nhập Bộ Nhớ")]
        [StringLength(150)]
        public string BoNho { get; set; }
        [Required(ErrorMessage = "Chưa nhập Dung Lương")]
        [StringLength(50)]
        public string DungLuongPin { get; set; }

        public int? luotXem { get; set; }

        [StringLength(50)]
        public string link { get; set; }
    }
}