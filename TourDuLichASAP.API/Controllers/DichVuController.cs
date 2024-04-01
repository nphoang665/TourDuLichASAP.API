using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Implementation;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private readonly IDichVuRepositories _dichVuRepositories;

        public DichVuController(IDichVuRepositories dichVuRepositories)
        {
            _dichVuRepositories = dichVuRepositories;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDichVu()
        {
            var dichVus = await _dichVuRepositories.GetAllAsync();
            
            var response = new List<DichVuDto>();
            foreach (var dichVu in dichVus)
            {
                response.Add(new DichVuDto
                {
                    IdDichVu = dichVu.IdDichVu,
                    TenDichVu = dichVu.TenDichVu,
                    DonViTinh = dichVu.DonViTinh,
                    GiaTien = dichVu.GiaTien,
                    TinhTrang = dichVu.TinhTrang,
                    GioBatDau = dichVu.GioBatDau,
                    GioKetThuc = dichVu.GioKetThuc,
                    NgayThem = dichVu.NgayThem
                });
            }
            return Ok(response);

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDichVU([FromBody] CreateDichVuRequestDto requestDto)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idDichVu = "DV" + randomValue.ToString("D4");

            var dichVu = new DichVu
            {
                 IdDichVu= idDichVu,
                TenDichVu = requestDto.TenDichVu,
                DonViTinh = requestDto.DonViTinh,
                GiaTien = requestDto.GiaTien,
                TinhTrang = "Đang hoạt động",
                GioBatDau = requestDto.GioBatDau,
                GioKetThuc = requestDto.GioKetThuc,
                NgayThem = DateTime.Now,
            };

             dichVu= await _dichVuRepositories.CreateAsync(dichVu);

            var response = new DichVuDto
            {
                IdDichVu = requestDto.IdDichVu,
                TenDichVu = requestDto.TenDichVu,
                DonViTinh = requestDto.DonViTinh,
                GiaTien = requestDto.GiaTien,
                TinhTrang = requestDto.TinhTrang,
                GioBatDau = requestDto.GioBatDau,
                GioKetThuc = requestDto.GioKetThuc,
                NgayThem = requestDto.NgayThem,

            };

            return Ok(response);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDichVuById(string id)
        {
            var dichVu = await _dichVuRepositories.GetByIdAsync(id);
            if (dichVu == null)
            {
                return NotFound();
            }
            var response = new DichVuDto
            {
                IdDichVu = dichVu.IdDichVu,
                TenDichVu = dichVu.TenDichVu,
                DonViTinh = dichVu.DonViTinh,
                GiaTien = dichVu.GiaTien,
                TinhTrang = dichVu.TinhTrang,
                GioBatDau = dichVu.GioBatDau,
                GioKetThuc = dichVu.GioKetThuc,
                NgayThem = dichVu.NgayThem,
            };
            return Ok(response);
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDichVu(string id, UpdateDichVuRequestDto requestDto)
        {
            var dichVu = new DichVu
            {
                IdDichVu = id,
                TenDichVu = requestDto.TenDichVu,
                DonViTinh = requestDto.DonViTinh,
                GiaTien = requestDto.GiaTien,
                TinhTrang = requestDto.TinhTrang,
                GioBatDau = requestDto.GioBatDau,
                GioKetThuc = requestDto.GioKetThuc,
                NgayThem = requestDto.NgayThem,
            };

            dichVu = await _dichVuRepositories.UpdateAsync(dichVu);
            if (dichVu == null)
            {
                return NotFound();
            }

            var response = new DichVuDto
            {
                IdDichVu = dichVu.IdDichVu,
                TenDichVu = dichVu.TenDichVu,
                DonViTinh = dichVu.DonViTinh,
                GiaTien = dichVu.GiaTien,
                TinhTrang = dichVu.TinhTrang,
                GioBatDau = dichVu.GioBatDau,
                GioKetThuc = dichVu.GioKetThuc,
                NgayThem = requestDto.NgayThem,
            };
            return Ok(response);
        }
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDichVu(string id)
        {
            var deleteDichVu = await _dichVuRepositories.DeleteAsync(id);
            if (deleteDichVu == null)
            {
                return NotFound();
            }
            var response = new DichVu
            {
                IdDichVu = id,
                TenDichVu = deleteDichVu.TenDichVu,
                DonViTinh = deleteDichVu.DonViTinh,
                GiaTien = deleteDichVu.GiaTien,
                TinhTrang = deleteDichVu.TinhTrang,
                GioBatDau = deleteDichVu.GioBatDau,
                GioKetThuc = deleteDichVu.GioKetThuc,
                NgayThem = deleteDichVu.NgayThem,
            };
            return Ok(response);
        }
    }
}
