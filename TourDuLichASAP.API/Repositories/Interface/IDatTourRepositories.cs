using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IDatTourRepositories
    {
        Task<DatTour> CreateAsync(DatTour datTour);
        Task<IEnumerable<DatTour>> GetAllAsync();
        Task<DatTour?> UpdateAsync(DatTour datTour);
        Task<DatTour?> DeleteAsync(string id);
        Task<DatTour?> GetByIdAsync(string id);
        Task<KhachHang> GetkhachHangById(string idKhachHang);
        Task<NhanVien> GetNhanVienById(string idNhanVien);
        Task<TourDuLich> GetTourDuLichById(string idTour);
        //hàm lấy đặt tour theo id tour
        Task<IEnumerable<DatTour>> GetTourDuLichByIdTour(string idTour);
    }
}
