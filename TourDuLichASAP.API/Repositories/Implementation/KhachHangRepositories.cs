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
        public async Task<IEnumerable<KhachHang>> GetAllAsync()
        {
            return await _db.KHACH_HANG.ToListAsync();
        }
    }
}
