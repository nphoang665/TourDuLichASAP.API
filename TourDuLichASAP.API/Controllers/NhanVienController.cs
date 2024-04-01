﻿using Microsoft.AspNetCore.Authorization;
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
            foreach (var nhanvien in nhanviens)
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
                });
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateNhanVien([FromBody] CreateNhanVienRequestDto requestDto)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idNhanVien = "NV" + randomValue.ToString("D4");

            var nhanVien = new NhanVien
            {
                IdNhanVien = idNhanVien,
                TenNhanVien = requestDto.TenNhanVien,
                SoDienThoai = requestDto.SoDienThoai,
                DiaChi = requestDto.DiaChi,
                CCCD = requestDto.CCCD,
                NgaySinh = requestDto.NgaySinh,
                Email = requestDto.Email,
                GioiTinh = requestDto.GioiTinh,
                NgayDangKy = DateTime.Now,
                ChucVu = requestDto.ChucVu,
                NgayVaoLam = requestDto.NgayVaoLam,
                AnhNhanVien = requestDto.AnhNhanVien,
                TinhTrang = "Đang hoạt động",
            };

            nhanVien = await _nhanVienRepositories.CreateAsync(nhanVien);

            var response = new NhanVienDto
            {
                IdNhanVien = requestDto.IdNhanVien,
                TenNhanVien = requestDto.TenNhanVien,
                SoDienThoai = requestDto.SoDienThoai,
                DiaChi = requestDto.DiaChi,
                CCCD = requestDto.CCCD,
                NgaySinh = requestDto.NgaySinh,
                Email = requestDto.Email,
                GioiTinh = requestDto.GioiTinh,
                NgayDangKy = requestDto.NgayDangKy,
                ChucVu = requestDto.ChucVu,
                NgayVaoLam = requestDto.NgayVaoLam,
                AnhNhanVien = requestDto.AnhNhanVien,
                TinhTrang = requestDto.TinhTrang,
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetNhanVienById(string id)
        {
            var nhanVien = await _nhanVienRepositories.GetByIdAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            var response = new NhanVienDto
            {
                IdNhanVien = nhanVien.IdNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,
                SoDienThoai = nhanVien.SoDienThoai,
                DiaChi = nhanVien.DiaChi,
                CCCD = nhanVien.CCCD,
                NgaySinh = nhanVien.NgaySinh,
                Email = nhanVien.Email,
                GioiTinh = nhanVien.GioiTinh,
                NgayDangKy = nhanVien.NgayDangKy,
                ChucVu = nhanVien.ChucVu,
                NgayVaoLam = nhanVien.NgayVaoLam,
                AnhNhanVien = nhanVien.AnhNhanVien,
                TinhTrang = nhanVien.TinhTrang,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateNhanVien(string id, UpdateNhanVienRequestDto requestDto)
        {
            var nhanVien = new NhanVien
            {
                IdNhanVien = id,
                TenNhanVien = requestDto.TenNhanVien,
                SoDienThoai = requestDto.SoDienThoai,
                DiaChi = requestDto.DiaChi,
                CCCD = requestDto.CCCD,
                NgaySinh = requestDto.NgaySinh,
                Email = requestDto.Email,
                GioiTinh = requestDto.GioiTinh,
                NgayDangKy = requestDto.NgayDangKy,
                ChucVu = requestDto.ChucVu,
                NgayVaoLam = requestDto.NgayVaoLam,
                AnhNhanVien = requestDto.AnhNhanVien,
                TinhTrang = requestDto.TinhTrang
            };

            nhanVien = await _nhanVienRepositories.UpdateAsync(nhanVien);
            if(nhanVien == null)
            {
                return NotFound();
            }

            var response = new NhanVienDto
            {
                IdNhanVien = nhanVien.IdNhanVien,
                TenNhanVien = nhanVien.TenNhanVien,
                SoDienThoai = nhanVien.SoDienThoai,
                DiaChi = nhanVien.DiaChi,
                CCCD = nhanVien.CCCD,
                NgaySinh = nhanVien.NgaySinh,
                Email = nhanVien.Email,
                GioiTinh = nhanVien.GioiTinh,
                NgayDangKy = nhanVien.NgayDangKy,
                ChucVu = nhanVien.ChucVu,
                NgayVaoLam = nhanVien.NgayVaoLam,
                AnhNhanVien = nhanVien.AnhNhanVien,
                TinhTrang = nhanVien.TinhTrang,
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteNhanVien(string id)
        {
            var deleteNhanVien = await _nhanVienRepositories.DeleteAsync(id);
            if(deleteNhanVien == null)
            {
                return NotFound();
            }
            var response = new NhanVien
            {
                IdNhanVien = id,
                TenNhanVien = deleteNhanVien.TenNhanVien,
                SoDienThoai = deleteNhanVien.SoDienThoai,
                DiaChi = deleteNhanVien.DiaChi,
                CCCD = deleteNhanVien.CCCD,
                NgaySinh = deleteNhanVien.NgaySinh,
                Email = deleteNhanVien.Email,
                GioiTinh = deleteNhanVien.GioiTinh,
                NgayDangKy = deleteNhanVien.NgayDangKy,
                ChucVu = deleteNhanVien.ChucVu,
                NgayVaoLam = deleteNhanVien.NgayVaoLam,
                AnhNhanVien = deleteNhanVien.AnhNhanVien,
                TinhTrang = deleteNhanVien.TinhTrang,
            };
            return Ok(response);
        }
    }
}
