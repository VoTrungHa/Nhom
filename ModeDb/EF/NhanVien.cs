namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        public long MaNV { get; set; }

        [Required]
        [StringLength(150)]
        public string TenNV { get; set; }

        [StringLength(150)]
        public string Diachi { get; set; }

        [StringLength(12)]
        public string SoDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool? GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public long? MaUse { get; set; }

        public virtual User User { get; set; }
    }
}
