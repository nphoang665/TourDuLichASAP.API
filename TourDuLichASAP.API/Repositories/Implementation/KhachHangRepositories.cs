using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class KhachHangRepositories : IKhachHangRepositories
    {
        private readonly ApplicationDbContext _db;

        public KhachHangRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<KhachHang> CreateAsync(KhachHang khachHang)
        {
            await _db.KHACH_HANG.AddAsync(khachHang);
            await _db.SaveChangesAsync();
            return khachHang;
        }

        public async Task<KhachHang?> DeleteAsync(string id)
        {
            var existingKhachHang = await _db.KHACH_HANG.FirstOrDefaultAsync(x => x.IdKhachHang == id);
            existingKhachHang.TinhTrang = "Ngưng hoạt động";
            if(existingKhachHang != null)
            {
                _db.KHACH_HANG.Update(existingKhachHang);
                await _db.SaveChangesAsync();
                return existingKhachHang;
            }
            return null;
        }

        public async Task<IEnumerable<KhachHang>> GetAllAsync()
        {
            return await _db.KHACH_HANG.ToListAsync();
        }

        public async Task<KhachHang> GetkhachHangById(string idKhachHang)
        {
            return await _db.KHACH_HANG.FirstOrDefaultAsync(x => x.IdKhachHang == idKhachHang);
        }

        public async Task<KhachHang?> UpdateAsync(KhachHang khachHang)
        {
            var existingKhachHang = await _db.KHACH_HANG.FirstOrDefaultAsync(x => x.IdKhachHang == khachHang.IdKhachHang);
                if(existingKhachHang == null)
            {
                return null;
            }
            _db.Entry(existingKhachHang).CurrentValues.SetValues(khachHang);
            await _db.SaveChangesAsync() ;
            return khachHang;
        }
    }
}
