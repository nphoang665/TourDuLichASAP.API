using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
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
    }
}
