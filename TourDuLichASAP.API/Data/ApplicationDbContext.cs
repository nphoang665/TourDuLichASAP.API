using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<DoiTac> DOI_TAC { get; set; }
        public DbSet<AnhDoiTac> ANH_DOI_TAC { get; set; }
        public DbSet<TourDuLich> TOUR_DU_LICH { get; set; }
        public DbSet<NhanVien> NHAN_VIEN { get; set; }
        public DbSet<KhachHang> KHACH_HANG { get; set; }
        public DbSet<AnhTour> ANH_TOUR { get; set; }
        public DbSet<DatTour> DAT_TOUR { get; set; }
        public DbSet<DanhGia> DANH_GIA { get; set; }
        public DbSet<DichVu> DICH_VU { get; set; }
        public DbSet<DichVuChiTiet> DICH_VU_CHI_TIET { get; set; }
        public DbSet<ThanhToan> THANH_TOAN { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DichVuChiTiet>()
       .HasOne(d => d.KhachHang)
       .WithMany()
       .HasForeignKey(d => d.IdKhachHang)
       .OnDelete(DeleteBehavior.Restrict); // hoặc DeleteBehavior.NoAction

            modelBuilder.Entity<DichVuChiTiet>()
                .HasOne(d => d.NhanVien)
                .WithMany()
                .HasForeignKey(d => d.IdNhanVien)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DichVuChiTiet>()
                .HasOne(d => d.DichVu)
                .WithMany()
                .HasForeignKey(d => d.IdDichVu)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DichVuChiTiet>()
                .HasOne(d => d.DatTour)
                .WithMany()
                .HasForeignKey(d => d.IdDatTour)
                .OnDelete(DeleteBehavior.Restrict);

            //THanh toan
            modelBuilder.Entity<ThanhToan>()
        .HasOne(t => t.KhachHang)
        .WithMany()
        .HasForeignKey(t => t.IdKhachHang)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.NhanVien)
                .WithMany()
                .HasForeignKey(t => t.IdNhanVien)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.DatTour)
                .WithMany()
                .HasForeignKey(t => t.IdDatTour)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.DichVuChiTiet)
                .WithMany()
                .HasForeignKey(t => t.IdDichVuChiTiet)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed dữ liệu mẫu
            modelBuilder.Entity<DoiTac>().HasData(
                new DoiTac
                {
                    IdDoiTac = "DT0001",
                    TenDoiTac = "Công ty cổ phần Du lịch Đắk Lắk",
                    Email = "sales@daklaktourist.com.vn",
                    SoDienThoai = "0908116466",
                    DiaChi = "01-03 Phan Chu Trinh, Tp. Buôn Ma Thuột, Đắk Lắk",
                    DanhGiaApp = 4.5f,
                    MoTa = "Công ty chuyên về kinh doanh khách sạn, nhà hàng, khu du lịch tại thành phố Đắk Lắk.",
                    NgayDangKy = new DateTime(2023, 1, 1),
                    TinhTrang = "Hoạt động"
                },
                new DoiTac
                {
                    IdDoiTac = "DT0002",
                    TenDoiTac = "Công ty TNHH Du lịch DakViet",
                    Email = "info@dakviettravel.com",
                    SoDienThoai = "0905057890",
                    DiaChi = "32 Nơ Trang Long, Tp. Buôn Ma Thuột, Đắk Lắk",
                    DanhGiaApp = 4.2f,
                    MoTa = "DakViet Travel, một địa chỉ du lịch đáng tin cậy, có trụ sở tại trung tâm của Việt Nam Tây Nguyên.",
                    NgayDangKy = new DateTime(2023, 2, 1),
                    TinhTrang = "Hoạt động"
                }
            );

        }

    }
}
