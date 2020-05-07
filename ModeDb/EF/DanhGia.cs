namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MaKH { get; set; }

        [StringLength(250)]
        public string noiDung { get; set; }

        public DateTime? time { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
