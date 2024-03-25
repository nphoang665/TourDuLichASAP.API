using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class LoginResponseDto
    {

        public string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public KhachHangDto KhachHang { get; set; }
        public NhanVienDto NhanVien { get; set; }
    }
}
