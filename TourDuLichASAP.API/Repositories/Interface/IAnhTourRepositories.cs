using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IAnhTourRepositories
    {
        Task<IEnumerable<AnhTour>> GetAllAsync();
        Task<IEnumerable<AnhTour>> GetImgTourById(string IdTour);
        Task<AnhTour> UploadImg(AnhTour anhTour);
        Task<AnhTour> DeleteImg(string IdAnhTour);
        Task<TourDuLich> GetTourById(string IdTour);
        string RemoveImgByName(string ImgTour);
    }
}
