using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using TourDuLichASAP.API.Models.Domain;
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
                    khachHang = danhGia.KhachHang,
                    Like = danhGia.Like,
                    DisLike = danhGia.DisLike,  
                }); 
            }

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> ThemDanhGia([FromBody] ThemDanhGiaDto request) {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idDanhGia = "DG" + randomValue.ToString("D4");
            if (request.IdTour == "null")
            {
                request.IdTour = null;
            }
            var danhgia = new DanhGia()
            {
                IdDanhGia = idDanhGia,
                IdKhachHang = "KH0001",
                IdTour = request.IdTour,
                DiemDanhGia = request.DiemDanhGia,
                NhanXet = request.NhanXet,
                ThoiGianDanhGia = request.ThoiGianDanhGia,
                Like = 0,
                DisLike = 0,

            };
            danhgia = await _danhGiaRepositories.ThemDanhGia(danhgia);
            var response = new DanhGiaDto
            {
                IdDanhGia = idDanhGia,
                IdKhachHang = "KH0001",
                IdTour = request.IdTour,
                DiemDanhGia = request.DiemDanhGia,
                NhanXet = request.NhanXet,
                ThoiGianDanhGia = request.ThoiGianDanhGia,
                Like = 0,
                DisLike = 0,
            };
            return Ok(response);
        } 
    }
}
