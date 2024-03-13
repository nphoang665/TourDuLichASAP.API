using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IDoiTacRepositories
    {
        Task<IEnumerable<DoiTac>> GetAllAsync();
    }
}
