using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class TourDuLich
    {
        [Key]
        [StringLength(6)]
        public string IdTour { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTour { get; set; }

        [Required]
        [StringLength(200)]
        public string LoaiTour { get; set; }

        [Required]
        [StringLength(100)]
        public string PhuongTienDiChuyen { get; set; }

        public string MoTa { get; set; } 

        public int SoLuongNguoiLon { get; set; }

        public int SoLuongTreEm { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

        [Required]
        [StringLength(50)]
        public string NoiKhoiHanh { get; set; }

        public int SoChoConNhan { get; set; }

        [StringLength(6)]
        [ForeignKey("DoiTac")]
        public string IdDoiTac { get; set; }

        public int GiaTreEm { get; set; }

        public int GiaNguoiLon { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgayThem { get; set; }

        public string? DichVuDiKem { get; set; } 

        [Required]
        [StringLength(100)]
        public string TinhTrang { get; set; }

        public DoiTac DoiTac { get; set; } 
    }
}
