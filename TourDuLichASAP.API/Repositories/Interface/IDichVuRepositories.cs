using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IDichVuRepositories
    {
        Task<IEnumerable<DichVu>> GetAllAsync();
    }
}
