using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class DatTourRepositories : IDatTourRepositories
    {
        private readonly ApplicationDbContext _db;

        public DatTourRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<DatTour> CreateAsync(DatTour datTour)
        {
            await _db.DAT_TOUR.AddAsync(datTour);
            await _db.SaveChangesAsync();
            return datTour;
        }

        public async Task<DatTour> DatTourChoKhachHang(DatTour datTour)
        {
            await _db.DAT_TOUR.AddAsync(datTour);
            await _db.SaveChangesAsync();
            return datTour;
        }

        public async Task<DatTour?> DeleteAsync(string id)
        {
            var existingDatTour = await _db.DAT_TOUR.FirstOrDefaultAsync(x => x.IdDatTour == id);
            existingDatTour.TinhTrang = "Đã hủy";
            if (existingDatTour != null)
            {
                _db.DAT_TOUR.Update(existingDatTour);
                await _db.SaveChangesAsync();
                return existingDatTour;
            }
            return null;
        }

        public async Task<IEnumerable<DatTour>> GetAllAsync()
        {
            return await _db.DAT_TOUR.Include(x=>x.KhachHang).Include(x=>x.NhanVien).Include(x=>x.TourDuLich).ToListAsync();
        }

        public async Task<DatTour?> GetByIdAsync(string id)
        {
            return await _db.DAT_TOUR.Include(x => x.KhachHang).Include(x => x.NhanVien).Include(x => x.TourDuLich).FirstOrDefaultAsync(x=>x.IdDatTour==id);
        }

        public async Task<KhachHang> GetkhachHangById(string idKhachHang)
        {
            return await _db.KHACH_HANG.FindAsync(idKhachHang);
        }

        public async Task<NhanVien> GetNhanVienById(string idNhanVien)
        {
            return await _db.NHAN_VIEN.FindAsync(idNhanVien);
        }

        public async Task<TourDuLich> GetTourDuLichById(string idTour)
        {
            return await _db.TOUR_DU_LICH.FindAsync(idTour);
        }

        public async Task<IEnumerable<DatTour>> GetTourDuLichByIdTour(string idTour)
        {
            return await _db.DAT_TOUR.Include(x => x.KhachHang).Include(x => x.NhanVien).Include(x => x.TourDuLich).Where(s=>s.IdTour == idTour).ToListAsync();
        }

        public async Task<DatTour?> UpdateAsync(DatTour datTour)
        {
            var existingDatTour = await _db.DAT_TOUR.Include(x => x.KhachHang).Include(x => x.NhanVien).Include(x => x.TourDuLich).FirstOrDefaultAsync(x => x.IdDatTour == datTour.IdDatTour);
            if (existingDatTour == null)
            {
                return null;
            }

            _db.Entry(existingDatTour).CurrentValues.SetValues(datTour);

            existingDatTour.KhachHang = datTour.KhachHang;
            existingDatTour.NhanVien = datTour.NhanVien;
            existingDatTour.TourDuLich = datTour.TourDuLich;

            await _db.SaveChangesAsync();
            return datTour;
        }
    }
}
