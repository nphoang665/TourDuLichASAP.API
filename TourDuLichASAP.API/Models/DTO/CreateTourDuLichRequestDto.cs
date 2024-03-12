using System.ComponentModel.DataAnnotations;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class CreateTourDuLichRequestDto
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

        [Required]
        public int SoLuongNguoiLon { get; set; }

        [Required]
        public int SoLuongTreEm { get; set; }

        [Required]
        public DateTime ThoiGianBatDau { get; set; }

        [Required]
        public DateTime ThoiGianKetThuc { get; set; }

        [Required]
        [StringLength(50)]
        public string NoiKhoiHanh { get; set; }

        [Required]
        public int SoChoConNhan { get; set; }

        [Required]
        [StringLength(6)]
        public string IdDoiTac { get; set; }

        [Required]
        public int GiaTreEm { get; set; }

        [Required]
        public int GiaNguoiLon { get; set; }

        public DateTime NgayThem { get; set; }

        public string? DichVuDiKem { get; set; }

        [Required]
        [StringLength(100)]
        public string TinhTrang { get; set; }
        public string[] ImgSelected { get; set; }

    }
}
