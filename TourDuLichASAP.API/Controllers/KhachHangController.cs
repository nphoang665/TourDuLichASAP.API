﻿using Microsoft.AspNetCore.Http;
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
                    MatKhau = khachHang.MatKhau,
                    NgayDangKy = khachHang.NgayDangKy
                });
            }

            return Ok(response);
        }

        [HttpPost]
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
                MatKhau = request.MatKhau,
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
                MatKhau = khachHang.MatKhau,
                NgayDangKy = khachHang.NgayDangKy
            };
            return Ok(response);
        }
    }
}
