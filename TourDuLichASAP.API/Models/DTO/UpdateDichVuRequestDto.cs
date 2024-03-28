using System.ComponentModel.DataAnnotations.Schema;

namespace TourDuLichASAP.API.Models.DTO
{
    public class UpdateDichVuRequestDto
    {
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public int GiaTien { get; set; }
        public string TinhTrang { get; set; }
        public TimeOnly GioBatDau { get; set; }
        public TimeOnly GioKetThuc { get; set; }
        [Column(TypeName = "Date")]
        public DateTime NgayThem { get; set; }
    }
}
