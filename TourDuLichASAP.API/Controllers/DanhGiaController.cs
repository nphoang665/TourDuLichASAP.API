using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhGiaController : ControllerBase
    {
        private readonly IDanhGiaRepositories _danhGiaRepositories;
        public DanhGiaController(IDanhGiaRepositories danhGiaRepositories)
        {
            _danhGiaRepositories = danhGiaRepositories;
        }
        [HttpGet]
        public async Task<IActionResult> LayDanhGia()
        {

            var danhGias = await _danhGiaRepositories.LayTatCaDanhGia();
            

            var response = new List<DanhGiaDto>();
            foreach (var danhGia in danhGias)
            {
                response.Add(new DanhGiaDto()
                {
                    IdDanhGia = danhGia.IdDanhGia,
                    IdKhachHang = danhGia.IdKhachHang,
                    IdTour = danhGia.IdTour,
                    DiemDanhGia = danhGia.DiemDanhGia,
                    NhanXet = danhGia.NhanXet,
                    ThoiGianDanhGia = danhGia.ThoiGianDanhGia,
                    khachHang = danhGia.KhachHang
                }); 
            }

            return Ok(response);
        }
    }
}
