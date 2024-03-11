using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangRepositories _khachHangRepositories;

        public KhachHangController(IKhachHangRepositories khachHangRepositories)
        {
            _khachHangRepositories = khachHangRepositories;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKhachHang()
        {
            var khachHangs = await _khachHangRepositories.GetAllAsync();

            var response = new List<KhachHangDto>();
            foreach(var khachHang in khachHangs)
            {
                response.Add(new KhachHangDto
                {
                    IdKhachHang = khachHang.IdKhachHang,
                    TenKhachHang = khachHang.TenKhachHang,
                    SoDienThoai = khachHang.SoDienThoai,
                    DiaChi = khachHang.DiaChi,
                    CCCD = khachHang.CCCD,
                    NgaySinh = khachHang.NgaySinh,
                    GioiTinh = khachHang.GioiTinh,
                    Email = khachHang.Email,
                    TinhTrang = khachHang.TinhTrang,
                    MatKhau = khachHang.MatKhau,
                    NgayDangKy = khachHang.NgayDangKy
                });
            }

            return Ok(response);
        }
    }
}
