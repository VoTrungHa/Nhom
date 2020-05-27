namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Redential")]
    public partial class Redential
    {
        [Required]
        [StringLength(50)]
        public string UserGroupID { get; set; }

        [Key]
        [StringLength(50)]
        public string RoleID { get; set; }
    }
}
