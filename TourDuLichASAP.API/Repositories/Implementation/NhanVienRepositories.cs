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
        public async Task<IEnumerable<NhanVien>> GetAllAsync()
        {
           return await _db.NHAN_VIEN.ToListAsync();
        }

        public async Task<NhanVien> ThemNhanVien(NhanVien nhanVien)
        {
            await _db.NHAN_VIEN.AddAsync(nhanVien);
            await _db.SaveChangesAsync();
            return nhanVien;

        }
    }
}
