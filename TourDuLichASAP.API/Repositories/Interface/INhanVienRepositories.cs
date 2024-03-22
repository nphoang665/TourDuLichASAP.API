using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface INhanVienRepositories
    {
        Task<IEnumerable<NhanVien>> GetAllAsync();
        Task<NhanVien> CreateAsync(NhanVien nhanVien);
        Task<NhanVien?> UpdateAsync(NhanVien nhanVien);
        Task<NhanVien?> DeleteAsync(string id);
        Task<NhanVien?> GetByIdAsync(string idNhanVien);
    }
}
