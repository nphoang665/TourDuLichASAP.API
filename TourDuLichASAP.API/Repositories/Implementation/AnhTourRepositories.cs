using Microsoft.AspNetCore.Http.HttpResults;
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

        public  string RemoveImgByName(string ImgTour)
        {
            //cắt chuỗi loại bỏ phần string localhost
            string convertImgTour = ImgTour.Substring(31);
            //tìm kiếm ảnh trong db ANH_TOUR
          var imgTour =   _db.ANH_TOUR.Where(s => s.ImgTour == convertImgTour);
            //nếu ảnh tour có trong db
            if (imgTour != null)
            {
                _db.ANH_TOUR.RemoveRange(imgTour);
                _db.SaveChanges();
                string s = "Xóa ảnh thành công";
                return s;

            }
            //nếu ảnh tour không có
            else
            {
                string s = "Xóa không thành công";
                return s;
            }
        }

        public async Task<AnhTour> UploadImg(AnhTour anhtour)
        {
            _db.ANH_TOUR.Add(anhtour);
            _db.SaveChanges();
            return anhtour;
        }
    }
}
