namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiMatHang")]
    public partial class LoaiMatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiMatHang()
        {
            Contents = new HashSet<Content>();
            MatHangs = new HashSet<MatHang>();
        }

        [Key]
        [StringLength(50)]
        [DisplayName("Loại Hàng")]
        public string MaLoaiHang { get; set; }

        [DisplayName("Loại Hàng")]
        [StringLength(150)]
        public string TenLoaiMH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatHang> MatHangs { get; set; }
    }
}
