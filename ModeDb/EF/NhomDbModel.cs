namespace ModeDb.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NhomDbModel : DbContext
    {
        public NhomDbModel()
            : base("name=NhomDbModel")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<DanhGia> DanhGias { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiMatHang> LoaiMatHangs { get; set; }
        public virtual DbSet<MatHang> MatHangs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.GiaThanh)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MucGiamGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Content>()
                .Property(e => e.GiaThanh)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Content>()
                .Property(e => e.MaLoaiHang)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasOptional(e => e.DanhGia)
                .WithRequired(e => e.KhachHang);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiMatHang>()
                .Property(e => e.MaLoaiHang)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.GiaThanh)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.MaLoaiHang)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.Ram)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.CameraT)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.CameraS)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.MatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatHang>()
                .HasMany(e => e.Contents)
                .WithRequired(e => e.MatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Ava)
                .IsFixedLength();
        }
    }
}
