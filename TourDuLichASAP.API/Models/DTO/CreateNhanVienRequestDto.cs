namespace TourDuLichASAP.API.Models.DTO
{
    public class CreateNhanVienRequestDto
    {
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string CCCD { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string AnhNhanVien { get; set; }
        public string TinhTrang { get; set; }
        public string MatKhau { get; set; }
    }
}
