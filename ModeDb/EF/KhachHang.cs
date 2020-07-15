namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public long MaKH { get; set; }

        [StringLength(150)]
        [DisplayName("Tên khách hàng")]
        public string TenKH { get; set; }

        [DisplayName("Địa chỉ")]
        [StringLength(150)]
        public string Diachi { get; set; }
        [DisplayName("Điện thoại")]
        [StringLength(12)]
        public string SoDT { get; set; }

        [DisplayName("Email")]
        [StringLength(100)]
        public string Email { get; set; }

        public long IDUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual User User { get; set; }
    }
}
