using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class DanhGiaRepositories : IDanhGiaRepositories
    {
        private readonly ApplicationDbContext _db;
        public DanhGiaRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DanhGia>> LayTatCaDanhGia()
        {
            return await _db.DANH_GIA.Include(x=>x.KhachHang).OrderByDescending(x=>x.ThoiGianDanhGia).ToListAsync();
         
        }

        public async Task<DanhGia> ThemDanhGia(DanhGia danhGia)
        {
            await _db.DANH_GIA.AddAsync(danhGia);
            await _db.SaveChangesAsync();
            return danhGia;
        }
    }
}
