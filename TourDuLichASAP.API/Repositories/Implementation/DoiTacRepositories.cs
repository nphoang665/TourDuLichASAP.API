using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class DoiTacRepositories : IDoiTacRepositories
    {
        private readonly ApplicationDbContext _db;
        public DoiTacRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<DoiTac>> GetAllAsync()
        {
            return await _db.DOI_TAC.ToListAsync();
        }
    }
}
