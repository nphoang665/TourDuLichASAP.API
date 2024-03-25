using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IDichVuRepositories
    {
        Task<IEnumerable<DichVu>> GetAllAsync();
        Task<DichVu> CreateAsync(DichVu dichVu);
        Task<DichVu?> UpdateAsync(DichVu dichVu);
        Task<DichVu>  DeleteAsync(string id);
        Task<DichVu> GetByIdAsync(string id);
    }
}
