namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            DanhGias = new HashSet<DanhGia>();
            KhachHangs = new HashSet<KhachHang>();
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        public long IDUser { get; set; }
         
        [StringLength(50)]
        public string IDGroup { get; set; }

        [Required(ErrorMessage="Email còn trống")]
        [DisplayName("Email")]
        [StringLength(100)]
        public string Email { get; set; }
         [Required(ErrorMessage = "Tên người dùng còn trống")]
         [DisplayName("Tên người dùng")]
        [StringLength(50)]
        public string HoTen { get; set; }
         [Required(ErrorMessage = "Điện thoại còn trống")]
         [DisplayName("Số điện thoại")]
        [StringLength(12)]
        public string Phone { get; set; }
         [Required(ErrorMessage = "Mật khẩu còn trống")]
         [DisplayName("Nhắc lại mật khẩu")]
        [StringLength(150)]
        public string PassWord { get; set; }
         [Required(ErrorMessage = "Mật khẩu còn trống")]
         [DisplayName("Nhắc lại mật khẩu")]
        [StringLength(150)]
        public string RePassWord { get; set; }

        public bool Status { get; set; }

        public bool? Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        public virtual Group Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
