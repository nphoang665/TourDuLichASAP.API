using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class NhanVien
    {
        [Key]
        [StringLength(6)]
        public string IdNhanVien { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhanVien { get; set; }

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
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(3)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgayDangKy { get; set; }

        [Required]
        [StringLength(15)]
        public string ChucVu { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgayVaoLam { get; set; }

        public string AnhNhanVien { get; set; } // TEXT in SQL Server maps to string in C#

        [Required]
        [StringLength(20)]
        public string TinhTrang { get; set; }
    }
}
