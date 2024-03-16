using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class DichVuChiTietDto
    {
        public string IdDichVuChiTiet { get; set; }
        public string IdDichVu { get; set; }
        public string IdKhachHang { get; set; }
        public string IdDatTour { get; set; }
        public string IdNhanVien { get; set; }
        public DateTime ThoiGianDichVu { get; set; }
        public int SoLuong { get; set; }
        public KhachHang KhachHang { get; set; }
        public NhanVien NhanVien { get; set; }
        public DichVu DichVu { get; set; }
        public DatTour DatTour { get; set; }
    }
}
