using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class DichVu
    {
        [Key]
        [StringLength(6)]
        public string IdDichVu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDichVu { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int GiaTien { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public TimeOnly GioBatDau { get; set; }

        public TimeOnly GioKetThuc { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgayThem { get; set; }
    }
}
