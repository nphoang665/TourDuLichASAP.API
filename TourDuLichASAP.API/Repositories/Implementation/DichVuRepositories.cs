using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class DichVuRepositories : IDichVuRepositories
    {
        private readonly ApplicationDbContext _db;

        public DichVuRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<DichVu>> GetAllAsync()
        {
            return await _db.DICH_VU.ToListAsync();
        }
    }
}
