using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.DTO;
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

            foreach(var dichVuChiTiet in dichVuChiTiets)
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
    }
}
