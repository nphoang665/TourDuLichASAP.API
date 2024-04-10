using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class ThanhToanRepositories : IThanhToanRepositories
    {
        private readonly ApplicationDbContext _db;

        public ThanhToanRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ThanhToan> CreateAsync(ThanhToan thanhToan)
        {
            await _db.THANH_TOAN.AddAsync(thanhToan);
            await _db.SaveChangesAsync();
            return thanhToan;
        }

        public async Task<ThanhToan?> DeleteAsync(string id)
        {
            var existingThanhToan = await _db.THANH_TOAN.FirstOrDefaultAsync(x => x.IdThanhToan == id);
            existingThanhToan.TinhTrang = "Đã hủy thanh toán";
            if (existingThanhToan != null)
            {
                _db.THANH_TOAN.Update(existingThanhToan);
                await _db.SaveChangesAsync();
                return existingThanhToan;
            }
            return null;
        }

        public async Task<IEnumerable<ThanhToan>> GetAllAsync()
        {

            return await _db.THANH_TOAN.ToListAsync();
        }

        public async Task<ThanhToan?> GetByIdAsync(string id)
        {
            return await _db.THANH_TOAN.Include(x => x.KhachHang).Include(x => x.NhanVien).Include(x=>x.DatTour).FirstOrDefaultAsync(x=>x.IdThanhToan==id);
        }

        public async Task<DatTour?> GetDatTourById(string idDatTour)
        {
            return await _db.DAT_TOUR.FindAsync(idDatTour);
        }

        public async Task<KhachHang?> GetKhachHangById(string idKhachHang)
        {
            return await _db.KHACH_HANG.FindAsync(idKhachHang);
        }

        public async Task<NhanVien?> GetNhanVienById(string idNhanVien)
        {
            return await _db.NHAN_VIEN.FindAsync(idNhanVien);
        }

        public async Task<ThanhToan?> UpdateAsync(ThanhToan thanhToan)
        {
            var existingThanhToan = await _db.THANH_TOAN.FirstOrDefaultAsync(x => x.IdThanhToan == thanhToan.IdThanhToan);
            if(existingThanhToan == null)
            {
                return null;
            }
            _db.Entry(existingThanhToan).CurrentValues.SetValues(thanhToan);
            await _db.SaveChangesAsync();
            return thanhToan;
        }
    }
}
