using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class DoiTac
    {
        [Key]
        [StringLength(6)]
        public string IdDoiTac { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDoiTac { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        public float? DanhGiaApp { get; set; }

        [StringLength(200)]
        public string? MoTa { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgayDangKy { get; set; }

        [Required]
        [StringLength(100)]
        public string TinhTrang { get; set; }

        // Relationship: One DoiTac to Many AnhDoiTac
        public ICollection<AnhDoiTac> AnhDoiTac { get; set; }
    }
}
