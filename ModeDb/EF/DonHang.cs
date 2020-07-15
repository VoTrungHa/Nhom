namespace ModeDb.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public long SoHoaDon { get; set; }

        public long MaKH { get; set; }

        public long? MaNV { get; set; }

          [DisplayName("Ngày đặt hàng")]
        public DateTime? NgayDH { get; set; }
        [DisplayName("Ngày giao hàng")]
        public DateTime? NgayGH { get; set; }
        [DisplayName("Nơi giao")]
        [StringLength(150)]
        public string NoiGiaoHang { get; set; }
        [DisplayName("Tổng tiền")]
        public decimal? TongTien { get; set; }
        [DisplayName("Ghi chú")]
        [StringLength(150)]
        public string ghichu { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
