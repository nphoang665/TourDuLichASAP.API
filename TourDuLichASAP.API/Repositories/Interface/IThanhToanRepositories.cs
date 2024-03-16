using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IThanhToanRepositories
    {
        Task<IEnumerable<ThanhToan>> GetAllAsync();
        Task<ThanhToan> CreateAsync(ThanhToan thanhToan);
        Task<ThanhToan?> UpdateAsync(ThanhToan thanhToan);
        Task<ThanhToan?> DeleteAsync(string id);
        Task<ThanhToan?> GetByIdAsync(string id);
        Task<DatTour?> GetDatTourById(string idDatTour);
        Task<KhachHang?> GetKhachHangById(string idKhachHang);
        Task<NhanVien?> GetNhanVienById(string idNhanVien);
    }
}
