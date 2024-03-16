using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class ThanhToanDto
    {
        public string IdThanhToan { get; set; }
        public string IdDatTour { get; set; }
        public string IdKhachHang { get; set; }
        public string IdNhanVien { get; set; }

        public int TongTienTour { get; set; }

        public int TongTienDichVu { get; set; }

        public int TongTien { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public DatTour DatTour { get; set; }
        public KhachHang KhachHang { get; set; }
        public NhanVien NhanVien { get; set; }
    }
}
