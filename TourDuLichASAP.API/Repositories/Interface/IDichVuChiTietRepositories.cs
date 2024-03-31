using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IDichVuChiTietRepositories
    {
        Task<IEnumerable<DichVuChiTiet>> GetAllAsync();
        Task<KhachHang> GetkhachHangById(string idKhachHang);
        Task<NhanVien> GetNhanVienById(string idNhanVien);
        Task<DatTour> GetDatTourById(string idDatTour);
        Task<DichVu> GetDichVuById(string idDichVu);
        //Task<DichVuChiTiet> SuaDichVuChiTiet(string id, DichVuChiTiet dichVuChiTiet);
        Task<DichVuChiTiet> ThemDichVuChiTiet(DichVuChiTiet dichVuChiTiet);
        Task<DichVuChiTiet> CapNhatDichVuChiTiet(DichVuChiTiet dichVuChiTiet);
        Task<DichVuChiTiet> XoaDichVuChiTiet(string id);
        Task<IEnumerable<DichVuChiTiet>> GetDichVuChiTietById(string id);


    }
}
