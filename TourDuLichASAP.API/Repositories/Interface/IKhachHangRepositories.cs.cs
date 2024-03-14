using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IKhachHangRepositories
    {
        Task<IEnumerable<KhachHang>> GetAllAsync();
        Task<KhachHang> CreateAsync(KhachHang khachHang);
        Task<KhachHang?> UpdateAsync(KhachHang khachHang);
        Task<KhachHang?> DeleteAsync(string id);
        Task<KhachHang> GetkhachHangById(string idKhachHang);


    }
}
