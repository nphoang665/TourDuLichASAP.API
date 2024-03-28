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
    public class DichVuChiTietController : ControllerBase
    {
        private readonly IDichVuChiTietRepositories _dichVuChiTietRepositories;

        public DichVuChiTietController(IDichVuChiTietRepositories dichVuChiTietRepositories)
        {
            _dichVuChiTietRepositories = dichVuChiTietRepositories;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDichVuChiTiet()
        {
            var dichVuChiTiets = await _dichVuChiTietRepositories.GetAllAsync();

            var response = new List<DichVuChiTietDto>();

            foreach (var dichVuChiTiet in dichVuChiTiets)
            {
                response.Add(new DichVuChiTietDto
                {
                    IdDichVuChiTiet = dichVuChiTiet.IdDichVuChiTiet,
                    IdDichVu = dichVuChiTiet.IdDichVu,
                    IdKhachHang = dichVuChiTiet.IdKhachHang,
                    IdDatTour = dichVuChiTiet.IdDatTour,
                    IdNhanVien = dichVuChiTiet.IdNhanVien,
                    ThoiGianDichVu = dichVuChiTiet.ThoiGianDichVu,
                    SoLuong = dichVuChiTiet.SoLuong,
                    KhachHang = dichVuChiTiet.KhachHang,
                    NhanVien = dichVuChiTiet.NhanVien,
                    DichVu = dichVuChiTiet.DichVu,
                    DatTour = dichVuChiTiet.DatTour

                });
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDichVuChiTiet([FromBody] CreateDichVuChiTietDto requestDto)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string id = "DCT" + randomValue.ToString("D3");

            var dichVu = new DichVuChiTiet
            {
                IdDichVuChiTiet = id,
                IdDichVu = requestDto.IdDichVu,
                IdKhachHang = requestDto.IdKhachHang,
                IdDatTour = requestDto.IdDatTour,
                IdNhanVien = requestDto.IdNhanVien,
                ThoiGianDichVu = requestDto.ThoiGianDichVu,
                SoLuong = requestDto.SoLuong,

            };

            dichVu = await _dichVuChiTietRepositories.ThemDichVuChiTiet(dichVu);

            var response = new DichVuChiTietDto
            {
                IdDichVuChiTiet = id,
                IdDichVu = requestDto.IdDichVu,
                IdKhachHang = requestDto.IdKhachHang,
                IdDatTour = requestDto.IdDatTour,
                IdNhanVien = requestDto.IdNhanVien,
                ThoiGianDichVu = requestDto.ThoiGianDichVu,
                SoLuong = requestDto.SoLuong,

            };

            return Ok(response);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDichVuChiTiet(string id, UpdateDichVuChiTietRequestDto requestDto)
        {
            var dichVu = new DichVuChiTiet
            {
                IdDichVuChiTiet = id,
                IdDichVu = requestDto.IdDichVu,
                IdKhachHang = requestDto.IdKhachHang,
                IdDatTour = requestDto.IdDatTour,
                IdNhanVien = requestDto.IdNhanVien,
                ThoiGianDichVu = requestDto.ThoiGianDichVu,
                SoLuong = requestDto.SoLuong,
            };

            dichVu = await _dichVuChiTietRepositories.SuaDichVuChiTiet(id, dichVu);
            if (dichVu == null)
            {
                return NotFound();
            }

            var response = new DichVuChiTietDto
            {
                IdDichVuChiTiet = id,
                IdDichVu = requestDto.IdDichVu,
                IdKhachHang = requestDto.IdKhachHang,
                IdDatTour = requestDto.IdDatTour,
                IdNhanVien = requestDto.IdNhanVien,
                ThoiGianDichVu = requestDto.ThoiGianDichVu,
                SoLuong = requestDto.SoLuong,
            };
            return Ok(response);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> XoaDichVuChiTiet(string id)
        {
            var deleteDichVu = await _dichVuChiTietRepositories.XoaDichVuChiTiet(id);
            if (deleteDichVu == null)
            {
                return NotFound();
            }
            var response = new DichVuChiTiet
            {
                IdDichVuChiTiet = id,
                IdDichVu = deleteDichVu.IdDichVu,
                IdKhachHang = deleteDichVu.IdKhachHang,
                IdDatTour = deleteDichVu.IdDatTour,
                IdNhanVien = deleteDichVu.IdNhanVien,
                ThoiGianDichVu = deleteDichVu.ThoiGianDichVu,
                SoLuong = deleteDichVu.SoLuong,
            };
            return Ok(response);

        }
    }
}