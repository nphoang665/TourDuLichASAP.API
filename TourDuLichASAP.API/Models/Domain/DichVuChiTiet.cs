using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class DichVuChiTiet
    {
        [Key]
        [StringLength(6)]
        public string IdDichVuChiTiet { get; set; }

        [Required]
        [StringLength(6)]
        public string IdDichVu { get; set; }

        [StringLength(6)]
        public string IdKhachHang { get; set; }

        [StringLength(6)]
        public string IdDatTour { get; set; }

        [StringLength(6)]
        public string IdNhanVien { get; set; }

        public DateTime ThoiGianDichVu { get; set; }

        public int SoLuong { get; set; }

        [ForeignKey("IdKhachHang")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("IdNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("IdDichVu")]
        public virtual DichVu DichVu { get; set; }

        [ForeignKey("IdDatTour")]
        public virtual DatTour DatTour { get; set; }
    }
}
