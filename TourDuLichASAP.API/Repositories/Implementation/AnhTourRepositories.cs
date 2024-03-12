using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class AnhTourRepositories : IAnhTourRepositories
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        public AnhTourRepositories(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }
        public Task<AnhTour> DeleteImg(string IdAnhTour)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnhTour>> GetAllAsync()
        {
           return await _db.ANH_TOUR.Include(x=>x.TourDuLich).ToListAsync();
        }

        public async Task<TourDuLich> GetTourById(string IdTour)
        {
            return await _db.TOUR_DU_LICH.FindAsync(IdTour);
        }

        public async Task<AnhTour> UploadImg(IFormFile imgFile, AnhTour anhTour)
        {
            var localPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads",$"{anhTour.ImgTour}");

            using var fileStream = new FileStream(localPath,FileMode.Create);
            await imgFile.CopyToAsync(fileStream);
            var httpRequest = _contextAccessor.HttpContext.Request;
            var urlPath = $"/Uploads/{anhTour.ImgTour}";
            await _db.ANH_TOUR.AddAsync(anhTour);
            await _db.SaveChangesAsync();
            return anhTour;
        }
    }
}
