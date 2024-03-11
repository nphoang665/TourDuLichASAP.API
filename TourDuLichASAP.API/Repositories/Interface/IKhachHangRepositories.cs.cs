using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IKhachHangRepositories
    {
        Task<IEnumerable<KhachHang>> GetAllAsync();
    }
}
