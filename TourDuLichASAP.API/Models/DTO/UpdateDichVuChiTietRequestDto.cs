using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class UpdateDichVuChiTietRequestDto
    {
        public string IdDichVuChiTiet { get; set; }
        public string IdDichVu { get; set; }
        public string IdKhachHang { get; set; }
        public string IdDatTour { get; set; }
        public string IdNhanVien { get; set; }
        public DateTime ThoiGianDichVu { get; set; }
        public int SoLuong { get; set; }

    }
}
