using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TourDuLichASAP.API.Models.Domain
{
    public class KhachHang
    {
        [Key]
        [StringLength(6)]
        public string IdKhachHang { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(3)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string TinhTrang { get; set; }
        

        [Column(TypeName = "Date")]
        public DateTime NgayDangKy { get; set; }
    }
}
