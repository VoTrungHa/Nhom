namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HeDieuHanh")]
    public partial class HeDieuHanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HeDieuHanh()
        {
            MatHangs = new HashSet<MatHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaHDH { get; set; }

        [StringLength(50)]
        public string TenHDH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatHang> MatHangs { get; set; }
    }
}
