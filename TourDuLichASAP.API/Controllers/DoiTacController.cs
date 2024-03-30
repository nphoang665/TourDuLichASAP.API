using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoiTacController : ControllerBase
    {
        private readonly IDoiTacRepositories _doiTacRepositories;
        public DoiTacController(IDoiTacRepositories doiTacRepositories)
        {
            _doiTacRepositories = doiTacRepositories;
        }
        [HttpGet]
       
        public async Task<IActionResult> GetAllDoiTac()
        {
            var doiTacs = await _doiTacRepositories.GetAllAsync();
            var response = new List<DoiTacDto>();
            ; foreach (var doitac in doiTacs)
            {
                response.Add(new DoiTacDto
                {
                    IdDoiTac = doitac.IdDoiTac,
                    TenDoiTac = doitac.TenDoiTac,
                    Email = doitac.Email,
                    SoDienThoai = doitac.SoDienThoai,
                    DiaChi = doitac.DiaChi,
                    DanhGiaApp = doitac.DanhGiaApp,
                    MoTa = doitac.MoTa,
                    NgayDangKy = doitac.NgayDangKy,
                    TinhTrang = doitac.TinhTrang,
                });
            }
            return Ok(response);
        }
    }
}
