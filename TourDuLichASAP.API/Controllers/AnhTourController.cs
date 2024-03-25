using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Implementation;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnhTourController : ControllerBase
    {


        private readonly IAnhTourRepositories _anhTourRepositories;

        public AnhTourController(IAnhTourRepositories anhTourRepositories)
        {
            _anhTourRepositories = anhTourRepositories;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAnhTour()
        {

            var anhTours = await _anhTourRepositories.GetAllAsync();

            var response = new List<AnhTourDto>();
            foreach (var anhtour in anhTours)
            {

                response.Add(new AnhTourDto
                {
                    IdAnhTour = anhtour.IdAnhTour,
                    IdTour = anhtour.IdTour,
                    ImgTour = anhtour.ImgTour,
                    NgayThem = anhtour.NgayThem,
                    TenTour = anhtour.TourDuLich.TenTour
                });
            }
            return Ok(response);
        }
        //[HttpPost]
        //public async Task<IActionResult> UploadImgTour([FromForm] IFormFile imgFile)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var uniqueFileName = DateTime.Now.ToString() + imgFile.FileName;
        //            var anhTour = new AnhTour
        //            {
        //                ImgTour = uniqueFileName,
        //                NgayThem = DateTime.Now,
                        
        //            };
        //            anhTour = await _anhTourRepositories.UploadImg(imgFile, anhTour);
        //            var response = new AnhTourDto
        //            {
        //                IdTour = anhTour.IdTour,
        //                ImgTour = anhTour.ImgTour,
        //                NgayThem = anhTour.NgayThem
        //            };
        //            return Ok(response);
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Ghi log cho ngoại lệ hoặc xử lý một cách phù hợp
        //        return StatusCode(500, $"Lỗi Server Nội Bộ: {ex.Message}");
        //    }
        //}
    }
}
