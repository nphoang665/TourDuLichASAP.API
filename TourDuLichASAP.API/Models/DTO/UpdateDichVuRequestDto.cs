namespace TourDuLichASAP.API.Models.DTO
{
    public class UpdateDichVuRequestDto
    {
        public string IdDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public int GiaTien { get; set; }
        public string TinhTrang { get; set; }
        public DateTime GioBatDau { get; set; }
        public DateTime GioKetThuc { get; set; }
        public DateTime NgayThem { get; set; }
    }
}
