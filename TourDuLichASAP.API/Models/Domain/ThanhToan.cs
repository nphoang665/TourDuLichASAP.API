using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class ThanhToan
    {
        [Key]
        [StringLength(6)]
        public string IdThanhToan { get; set; }

        [Required]
        [StringLength(6)]
        public string IdDichVuChiTiet { get; set; }

        [Required]
        [StringLength(6)]
        public string IdDatTour { get; set; }

        [Required]
        [StringLength(6)]
        public string IdKhachHang { get; set; }

        [Required]
        [StringLength(6)]
        public string IdNhanVien { get; set; }

        public int TongTienTour { get; set; }

        public int TongTienDichVu { get; set; }

        public int TongTien { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public DateTime NgayThanhToan { get; set; }

        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [ForeignKey("IdDichVuChiTiet")]
        public virtual DichVuChiTiet DichVuChiTiet { get; set; }

        [ForeignKey("IdDatTour")]
        public virtual DatTour DatTour { get; set; }

        [ForeignKey("IdKhachHang")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("IdNhanVien")]
        public virtual NhanVien NhanVien { get; set; }
    }
}
