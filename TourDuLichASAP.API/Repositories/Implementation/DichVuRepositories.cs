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

        public async Task<DichVu> CreateAsync(DichVu dichVu)
        {
            await _db.DICH_VU.AddAsync(dichVu);
            await _db.SaveChangesAsync();
            return dichVu;
        }

        public async Task<DichVu?> DeleteAsync(string id)
        {
            var existingDichVu = await _db.DICH_VU.FirstOrDefaultAsync(x => x.IdDichVu == id);
            existingDichVu.TinhTrang = "Ngưng hoạt động";
            if (existingDichVu != null)
            {
                _db.DICH_VU.Update(existingDichVu);
                await _db.SaveChangesAsync();
                return existingDichVu;
            }
            return null;
        }

        public async Task<IEnumerable<DichVu>> GetAllAsync()
        {
            return await _db.DICH_VU.ToListAsync();
        }

        public async Task<DichVu?> UpdateAsync(DichVu dichVu)
        {
            var existingDichVu = await _db.DICH_VU.FirstOrDefaultAsync(x => x.IdDichVu == dichVu.IdDichVu);
            if (existingDichVu == null)
            {
                return null;
            }
            _db.Entry(existingDichVu).CurrentValues.SetValues(dichVu);
            await _db.SaveChangesAsync();
            return dichVu;
        }
        public async Task<DichVu?> GetByIdAsync(string idDichVU)
        {
            return await _db.DICH_VU.FirstOrDefaultAsync(x => x.IdDichVu == idDichVU);
        }
    }
}
