namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        
        [Key]
        [StringLength(100)]
        [Required(ErrorMessage = "Bạn chưa nhập Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập Họ Tên")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "bạn chưa nhập số điện thoại")]
        [StringLength(12)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "bạn chưa nhập mật khẩu")]
        [StringLength(150)]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "bạn chưa nhập lại mật khẩu")]
        [StringLength(150)]
        public string RePassWord { get; set; }

        public bool Status { get; set; }

        public bool? Admin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
