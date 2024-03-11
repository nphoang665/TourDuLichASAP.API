using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepositories _nhanVienRepositories;

        public NhanVienController(INhanVienRepositories nhanVienRepositories)
        {
            _nhanVienRepositories = nhanVienRepositories;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhanvien()
        {
            var nhanviens = await _nhanVienRepositories.GetAllAsync();

            var response = new List<NhanVienDto>();
            foreach(var nhanvien in nhanviens)
            {
                response.Add(new NhanVienDto
                {
                    IdNhanVien = nhanvien.IdNhanVien,
                    TenNhanVien = nhanvien.TenNhanVien,
                    SoDienThoai = nhanvien.SoDienThoai,
                    DiaChi = nhanvien.DiaChi,
                    CCCD = nhanvien.CCCD,
                    NgaySinh = nhanvien.NgaySinh,
                    Email = nhanvien.Email,
                    GioiTinh = nhanvien.GioiTinh,
                    NgayDangKy = nhanvien.NgayDangKy,
                    ChucVu = nhanvien.ChucVu,
                    NgayVaoLam = nhanvien.NgayVaoLam,
                    AnhNhanVien = nhanvien.AnhNhanVien,
                    TinhTrang = nhanvien.TinhTrang,
                    MatKhau = nhanvien.MatKhau
                });
            }
            return Ok(response);
        }
    }
}
