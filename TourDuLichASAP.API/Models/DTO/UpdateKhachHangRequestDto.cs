namespace TourDuLichASAP.API.Models.DTO
{
    public class UpdateKhachHangRequestDto
    {
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string CCCD { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgayDangKy { get; set; }
    }
}
