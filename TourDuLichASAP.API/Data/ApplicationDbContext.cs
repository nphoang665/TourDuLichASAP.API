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
                    TinhTrang = "Đang hợp tác"
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
                    TinhTrang = "Đang hợp tác"
                }
            );


            //NhanVien
            modelBuilder.Entity<NhanVien>().HasData(
           new NhanVien
           {
               IdNhanVien = "NV0001",
               TenNhanVien = "Trần Thị Thanh",
               SoDienThoai = "0987654321",
               DiaChi = "123 Lê Thánh Tông, Buôn Ma Thuột",
               CCCD = "987654321098",
               NgaySinh = new DateTime(1995, 5, 10),
               Email = "ttb@example.com",
               GioiTinh = "Nữ",
               NgayDangKy = DateTime.Now,
               ChucVu = "Nhân viên",
               NgayVaoLam = DateTime.Now,
               AnhNhanVien = "url_anh",
               TinhTrang = "Đang hoạt động",
               MatKhau = "password123"
           },
           new NhanVien
           {
               IdNhanVien = "NV0002",
               TenNhanVien = "Lê Văn Khánh",
               SoDienThoai = "0365478912",
               DiaChi = "111 Hà Huy Tập, Buôn Ma Thuột",
               CCCD = "456789123456",
               NgaySinh = new DateTime(1988, 3, 15),
               Email = "lvc@example.com",
               GioiTinh = "Nam",
               NgayDangKy = DateTime.Now,
               ChucVu = "Nhân viên",
               NgayVaoLam = DateTime.Now,
               AnhNhanVien = "url_anh",
               TinhTrang = "Đang hoạt động",
               MatKhau = "abc123"
           }
       );

            //KhachHang
            modelBuilder.Entity<KhachHang>().HasData(
            new KhachHang
            {
                IdKhachHang = "KH0001",
                TenKhachHang = "Nguyễn Thị C",
                SoDienThoai = "0987654321",
                DiaChi = "123 Đường A, Quận 1, TP. HCM",
                CCCD = "123456789012",
                NgaySinh = new DateTime(1990, 1, 1),
                GioiTinh = "Nữ",
                Email = "ntc@example.com",
                TinhTrang = "Đang hoạt động",
                MatKhau = "password123",
                NgayDangKy = DateTime.Now
            },
            new KhachHang
            {
                IdKhachHang = "KH0002",
                TenKhachHang = "Trần Văn D",
                SoDienThoai = "0365478912",
                DiaChi = "456 Đường S, Quận 5, TP. HCM",
                CCCD = "987654321098",
                NgaySinh = new DateTime(1988, 3, 15),
                GioiTinh = "Nam",
                Email = "tvd@example.com",
                TinhTrang = "Đang hoạt động",
                MatKhau = "abc123",
                NgayDangKy = DateTime.Now
            }
        );

            modelBuilder.Entity<TourDuLich>().HasData(
             new TourDuLich
             {
                 IdTour = "TDL001",
                 TenTour = "Thác Dray Nur",
                 LoaiTour = "Tham quan thác",
                 PhuongTienDiChuyen = "Xe ô tô du lịch",
                 MoTa = "Thăm quan thác Dray Nur nổi tiếng với khung cảnh thiên nhiên hùng vĩ, kỳ vĩ.",
                 SoLuongNguoiLon = 30,
                 SoLuongTreEm = 15,
                 ThoiGianBatDau = new DateTime(2024, 4, 20),
                 ThoiGianKetThuc = new DateTime(2024, 4, 21),
                 NoiKhoiHanh = "Buôn Ma Thuột",
                 SoChoConNhan = 45,
                 IdDoiTac = "DT0002",
                 GiaTreEm = 500000,
                 GiaNguoiLon = 1000000,
                 NgayThem = DateTime.Now,
                 DichVuDiKem = "Bữa ăn trưa, vé tham quan",
                 TinhTrang = "Đang hoạt động"
             },
             new TourDuLich
             {
                 IdTour = "TDL002",
                 TenTour = "Cà phê sân vườn",
                 LoaiTour = "Thăm quan vườn cà phê",
                 PhuongTienDiChuyen = "Xe máy",
                 MoTa = "Tham quan và trải nghiệm cuộc sống của người dân Buôn Ma Thuột tại các vườn cà phê sân vườn.",
                 SoLuongNguoiLon = 20,
                 SoLuongTreEm = 10,
                 ThoiGianBatDau = new DateTime(2024, 4, 22),
                 ThoiGianKetThuc = new DateTime(2024, 4, 23),
                 NoiKhoiHanh = "Buôn Ma Thuột",
                 SoChoConNhan = 30,
                 IdDoiTac = "DT0001",
                 GiaTreEm = 300000,
                 GiaNguoiLon = 700000,
                 NgayThem = DateTime.Now,
                 DichVuDiKem = "Hướng dẫn viên, nước uống",
                 TinhTrang = "Đang hoạt động"
             }
         );

            modelBuilder.Entity<DatTour>().HasData(
           new DatTour
           {
               IdDatTour = "TLD002",
               IdKhachHang = "KH0001",
               IdTour = "TDL001",
               SoLuongNguoiLon = 2,
               SoLuongTreEm = 1,
               GhiChu = "Yêu cầu đưa đón",
               IdNhanVien = "NV0001",
               ThoiGianDatTour = DateTime.Now,
               TinhTrang = "Chờ xác nhận"
           }
       );



        }

    }
}
