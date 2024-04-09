using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
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
                    NgayDangKy = khachHang.NgayDangKy
                });
            }

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Nhân viên, Admin")]
        public async Task<IActionResult> CreateKhachHang([FromBody] CreateKhachHangRequestDto request)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idKhachHang = "KH" + randomValue.ToString("D4");

            var khachHang = new KhachHang
            {
                IdKhachHang = idKhachHang,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiaChi = request.DiaChi,
                CCCD = request.CCCD,
                NgaySinh = request.NgaySinh,
                GioiTinh = request.GioiTinh,
                Email = request.Email,
                TinhTrang = "Đang hoạt động",
                NgayDangKy = DateTime.Now,
            };
            khachHang = await _khachHangRepositories.CreateAsync(khachHang);
            var response = new KhachHangDto
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
                NgayDangKy = khachHang.NgayDangKy
            };
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetKhachHangById(string id)
        {
            var khachHang = await _khachHangRepositories.GetkhachHangById(id);
            if (khachHang is null)
            {
                return NotFound();
            }

            var response = new KhachHangDto
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
                NgayDangKy = khachHang.NgayDangKy
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        //[Authorize(Roles = "Nhân viên, Admin")]
        public async Task<IActionResult> UpdateKhachHang(string id, UpdateKhachHangRequestDto request)
        {
            var khachHang = new KhachHang
            {
                IdKhachHang = id,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiaChi = request.DiaChi,
                CCCD = request.CCCD,
                NgaySinh = request.NgaySinh,
                GioiTinh = request.GioiTinh,
                Email = request.Email,
                TinhTrang = request.TinhTrang,
                NgayDangKy = request.NgayDangKy,
            };
            var updateKhachHang = await _khachHangRepositories.UpdateAsync(khachHang);
            if(updateKhachHang == null)
            {
                return NotFound();
            }

            var response = new KhachHangDto
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
                NgayDangKy = khachHang.NgayDangKy
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Nhân viên, Admin")]
        public async Task<IActionResult>DeleteKhachHang(string id)
        {
            var deleteKhachHang = await _khachHangRepositories.DeleteAsync(id);
            if (deleteKhachHang == null)
            {
                return NotFound();
            }

            var response = new KhachHang
            {
                IdKhachHang = id,
                TenKhachHang = deleteKhachHang.TenKhachHang,
                SoDienThoai = deleteKhachHang.SoDienThoai,
                DiaChi = deleteKhachHang.DiaChi,
                CCCD = deleteKhachHang.CCCD,
                NgaySinh = deleteKhachHang.NgaySinh,
                GioiTinh = deleteKhachHang.GioiTinh,
                Email = deleteKhachHang.Email,
                TinhTrang = deleteKhachHang.TinhTrang,
                NgayDangKy = deleteKhachHang.NgayDangKy,
            };
            return Ok(response);
        }
    }
}
