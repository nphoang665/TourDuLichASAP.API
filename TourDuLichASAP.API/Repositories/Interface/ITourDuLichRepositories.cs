using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface ITourDuLichRepositories
    {
        Task<TourDuLich> CreateAsync(TourDuLich tourDuLich);
        Task<IEnumerable<TourDuLich>> GetAllAsync();
        Task<DoiTac> GetDoiTacAsync(string idDoiTac);
        Task<TourDuLich?> UpdateAsync(TourDuLich tourDuLich);
        Task<TourDuLich?> DeleteAsync(string id);
        Task<TourDuLich?> GetByIdAsync(string id);
    }
}
