using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class DatTourDto
    {
        public string IdDatTour { get; set; }
        public string IdKhachHang { get; set; }
        public string IdTour { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public string GhiChu { get; set; }
        public string IdNhanVien { get; set; }
        public DateTime ThoiGianDatTour { get; set; }
        public string TinhTrang { get; set; }
        public string KhachHang { get; set; }  // Ensure this is a string
        public string NhanVien { get; set; }
        public string TourDuLich { get; set; }
    }
}
