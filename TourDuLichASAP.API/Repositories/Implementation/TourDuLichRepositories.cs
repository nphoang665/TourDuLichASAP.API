using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class TourDuLichRepositories : ITourDuLichRepositories
    {
        private readonly ApplicationDbContext _db;

        public TourDuLichRepositories(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<TourDuLich> CreateAsync(TourDuLich tourDuLich)
        {
            await _db.TOUR_DU_LICH.AddAsync(tourDuLich);
            await _db.SaveChangesAsync();
            return tourDuLich;
        }

        public async Task<TourDuLich?> DeleteAsync(string id)
        {
            var existingTuorDuLich = await _db.TOUR_DU_LICH.FirstOrDefaultAsync(x=>x.IdTour==id);
            existingTuorDuLich.TinhTrang = "Ngưng hoạt động";
            if(existingTuorDuLich !=null)
            {
                _db.TOUR_DU_LICH.Update(existingTuorDuLich);
                await _db.SaveChangesAsync();
                return existingTuorDuLich;
            }
            return null;
        }

        public async Task<IEnumerable<TourDuLich>> GetAllAsync()
        {
            return await _db.TOUR_DU_LICH.Include(x => x.DoiTac).ToListAsync();
        }

        public async Task<IEnumerable<AnhTour>> GetAnhTourByIdAsync(string idTour)
        {
           var _get_TourDuLich= await _db.ANH_TOUR.Where(s=>s.IdTour ==idTour).ToListAsync();
            foreach (var item in _get_TourDuLich)
            {
                item.TourDuLich = null;
            }
            return _get_TourDuLich;
        }

        public async Task<TourDuLich?> GetByIdAsync(string id)
        {
            return await _db.TOUR_DU_LICH.Include(x => x.DoiTac).FirstOrDefaultAsync(x => x.IdTour == id);
        }

        public async Task<DoiTac> GetDoiTacAsync(string idDoiTac)
        {
            return await _db.DOI_TAC.FindAsync(idDoiTac);
        }

        public async Task<TourDuLich?> UpdateAsync(TourDuLich tourDuLich)
        {
            var existingTourDuLich = await _db.TOUR_DU_LICH.Include(x => x.DoiTac).FirstOrDefaultAsync(x => x.IdTour == tourDuLich.IdTour);
            if (existingTourDuLich == null)
            {
                return null;
            }

            _db.Entry(existingTourDuLich).CurrentValues.SetValues(tourDuLich);

            existingTourDuLich.DoiTac = tourDuLich.DoiTac;

            await _db.SaveChangesAsync();
            return tourDuLich;
        }

       
    }
}
