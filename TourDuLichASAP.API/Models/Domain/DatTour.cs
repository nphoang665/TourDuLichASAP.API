using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class DatTour
    {
        [Key]
        [StringLength(6)]
        public string IdDatTour { get; set; }

        [Required]
        [StringLength(6)]
        [ForeignKey("KhachHang")]
        public string IdKhachHang { get; set; }

        [Required]
        [StringLength(6)]
        [ForeignKey("TourDuLich")]
        public string IdTour { get; set; }

        public int SoLuongNguoiLon { get; set; }

        public int SoLuongTreEm { get; set; }

        public string? GhiChu { get; set; }

        [StringLength(6)]
        [ForeignKey("NhanVien")]
        public string? IdNhanVien { get; set; }

        public DateTime ThoiGianDatTour { get; set; }

        [Required]
        [StringLength(100)]
        public string TinhTrang { get; set; }

        // Navigation properties
        public KhachHang? KhachHang { get; set; }
        public TourDuLich? TourDuLich { get; set; }
        public NhanVien? NhanVien { get; set; }
    }
}
