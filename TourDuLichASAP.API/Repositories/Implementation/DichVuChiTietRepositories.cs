using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class DichVuChiTietRepositories : IDichVuChiTietRepositories
    {
        private readonly ApplicationDbContext _db;

        public DichVuChiTietRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<DichVuChiTiet>> GetAllAsync()
        {
           return await _db.DICH_VU_CHI_TIET.Include(x=>x.KhachHang).Include(x=>x.DichVu).Include(x=>x.DatTour).Include(x=>x.NhanVien).ToListAsync();
        }

        public async Task<DatTour> GetDatTourById(string idDatTour)
        {
            return await _db.DAT_TOUR.FindAsync(idDatTour);
        }

        public async Task<DichVu> GetDichVuById(string idDichVu)
        {
            return await _db.DICH_VU.FirstAsync(dv => dv.IdDichVu == idDichVu);
        }

        public async Task<KhachHang> GetkhachHangById(string idKhachHang)
        {
            return await _db.KHACH_HANG.FirstAsync(kh => kh.IdKhachHang == idKhachHang);
        }

        public async Task<NhanVien> GetNhanVienById(string idNhanVien)
        {
            return await _db.NHAN_VIEN.FirstAsync(nv => nv.IdNhanVien == idNhanVien);
        }

        public async Task<DichVuChiTiet> ThemDichVuChiTiet(DichVuChiTiet dichVuChiTiet)
        {
            await _db.DICH_VU_CHI_TIET.AddAsync(dichVuChiTiet);
            await _db.SaveChangesAsync();
            return dichVuChiTiet;
        }
    }
}
