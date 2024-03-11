using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface INhanVienRepositories
    {
        Task<IEnumerable<NhanVien>> GetAllAsync();
    }
}
