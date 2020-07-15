﻿namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public long MaNV { get; set; }

         [DisplayName("Tên Nhân Viên")]
        [StringLength(50)]
        public string TenNV { get; set; }

         [DisplayName("Địa Chỉ")]
        [StringLength(100)]
        public string DiaChi { get; set; }
         [DisplayName("Điện thoại")]
        [StringLength(20)]
        public string SoDT { get; set; }
         [DisplayName("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        public long IDUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual User User { get; set; }
    }
}
