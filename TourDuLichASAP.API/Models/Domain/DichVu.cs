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

        public DateTime GioBatDau { get; set; }

        public DateTime GioKetThuc { get; set; }

        [Column(TypeName = "Date")]
        public DateTime NgayThem { get; set; }
    }
}
