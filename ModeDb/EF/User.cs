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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        [StringLength(150)]
        public string UserName { get; set; }

        [Key]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(150)]
        public string PassWord { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        public bool? Status { get; set; }

        public bool? Admin { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string Ava { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
