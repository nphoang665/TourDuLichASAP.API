using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class NhanVienRepositories : INhanVienRepositories
    {
        private readonly ApplicationDbContext _db;

        public NhanVienRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<NhanVien> CreateAsync(NhanVien nhanVien)
        {
            await _db.NHAN_VIEN.AddAsync(nhanVien);
            await _db.SaveChangesAsync();
            return nhanVien;
        }

        public async Task<NhanVien?> DeleteAsync(string id)
        {
           var existingNhanVien = await _db.NHAN_VIEN.FirstOrDefaultAsync(x=>x.IdNhanVien == id);
            existingNhanVien.TinhTrang = "Đã nghỉ việc";
            if(existingNhanVien != null)
            {
                _db.NHAN_VIEN.Update(existingNhanVien);
                await _db.SaveChangesAsync();
                return existingNhanVien;
            }
            return null;
        }

        public async Task<IEnumerable<NhanVien>> GetAllAsync()
        {
           return await _db.NHAN_VIEN.ToListAsync();
        }

        public async Task<NhanVien?> GetByIdAsync(string idNhanVien)
        {
            return await _db.NHAN_VIEN.FirstOrDefaultAsync(x=>x.IdNhanVien==idNhanVien);
        }

        public async Task<NhanVien?> UpdateAsync(NhanVien nhanVien)
        {
            var existingNhanVien = await _db.NHAN_VIEN.FirstOrDefaultAsync(x => x.IdNhanVien == nhanVien.IdNhanVien);
            if(existingNhanVien == null)
            {
                return null;
            }
            _db.Entry(existingNhanVien).CurrentValues.SetValues(nhanVien);
            await _db.SaveChangesAsync() ;
            return nhanVien;
        }
    }
}
