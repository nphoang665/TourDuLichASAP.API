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
        //[HttpPut]
        //[Route("{id}")]
        //public async Task<IActionResult> UpdateDichVuChiTiet(string id, UpdateDichVuChiTietRequestDto requestDto)
        //{
        //    var dichVu = new DichVuChiTiet
        //    {
        //        IdDichVuChiTiet = id,
        //        IdDichVu = requestDto.IdDichVu,
        //        IdKhachHang = requestDto.IdKhachHang,
        //        IdDatTour = requestDto.IdDatTour,
        //        IdNhanVien = requestDto.IdNhanVien,
        //        ThoiGianDichVu = requestDto.ThoiGianDichVu,
        //        SoLuong = requestDto.SoLuong,
        //    };

        //    dichVu = await _dichVuChiTietRepositories.SuaDichVuChiTiet(id, dichVu);
        //    if (dichVu == null)
        //    {
        //        return NotFound();
        //    }

        //    var response = new DichVuChiTietDto
        //    {
        //        IdDichVuChiTiet = id,
        //        IdDichVu = requestDto.IdDichVu,
        //        IdKhachHang = requestDto.IdKhachHang,
        //        IdDatTour = requestDto.IdDatTour,
        //        IdNhanVien = requestDto.IdNhanVien,
        //        ThoiGianDichVu = requestDto.ThoiGianDichVu,
        //        SoLuong = requestDto.SoLuong,
        //    };
        //    return Ok(response);
        //}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> CreateDichVuChiTiet(string id, List<CreateDichVuChiTietRequestDto> requestDto)
        
        {
            try
            {

            
            //mảng chứa những idDichVuChiTiet được xử lý
            List<string> list_DichVuHandler = new List<string>();
            var getAllDichVuFormDb = await _dichVuChiTietRepositories.GetAllAsync();
            foreach (var dv in requestDto)
            {
                //lấy full dịch vụ từ db
                //kiểm tra có trùng mã khách hàng, mã đặt tour, mã dịch vụ không ? 
                var existDichVu = getAllDichVuFormDb.FirstOrDefault(s => s.IdDatTour == dv.IdDatTour && s.IdDichVu == dv.IdDichVu && s.IdKhachHang == dv.IdKhachHang);
                //nếu khác mã dịch vụ chi tiết tồn tại rồi
                if (existDichVu != null) {
                    //kiểm tra xem có sự thay đổi số lượng.
                    var isChangeSoLuong = getAllDichVuFormDb.FirstOrDefault(s => s.IdDichVuChiTiet == existDichVu.IdDichVuChiTiet && s.SoLuong != dv.SoLuong);
                    //nếu có sự thay đổi về số lượng
                    if (isChangeSoLuong != null)
                    {
                        //thực hiện việc sửa số lượng dịch vụ theo id
                        var dichVu = new DichVuChiTiet
                        {
                            IdDichVuChiTiet = existDichVu.IdDichVuChiTiet,
                            IdDichVu = dv.IdDichVu,
                            IdKhachHang = dv.IdKhachHang,
                            IdDatTour = dv.IdDatTour,
                            IdNhanVien = dv.IdNhanVien,
                            ThoiGianDichVu = dv.ThoiGianDichVu,
                            SoLuong = dv.SoLuong,
                        };
                        dichVu = await _dichVuChiTietRepositories.CapNhatDichVuChiTiet(dichVu);
                    }
                    list_DichVuHandler.Add(existDichVu.IdDichVuChiTiet);

                }
                //nếu mã dịch vụ chi tiết chưa tồn tại trong db
                else
                {
                    //thực hiện việc thêm mới dịch vụ
                    Random random = new Random();
                    int randomValue = random.Next(1000);
                    string idDichVuChiTiet = "DCT" + randomValue.ToString("D3");
                    var dichVu = new DichVuChiTiet
                    {
                        IdDichVuChiTiet = idDichVuChiTiet,
                        IdDichVu = dv.IdDichVu,
                        IdKhachHang = dv.IdKhachHang,
                        IdDatTour = dv.IdDatTour,
                        IdNhanVien = dv.IdNhanVien,
                        ThoiGianDichVu = dv.ThoiGianDichVu,
                        SoLuong = dv.SoLuong,
                    };
                    dichVu = await _dichVuChiTietRepositories.ThemDichVuChiTiet(dichVu);
                    list_DichVuHandler.Add(idDichVuChiTiet);
                }
              }
            //khai báo list những idDichVuChiTiet không còn sử dụng 
            List<string> list_IdDichVuChiTietKhongConSuDung = new List<string>();
            //kiểm tra những idDichVuChiTiet nào không còn được sử dụng
            //if (list_DichVuHandler != null)
            {
                foreach (var iddv in getAllDichVuFormDb)
                {
                    if (!list_DichVuHandler.Contains(iddv.IdDichVuChiTiet))
                    {
                        list_IdDichVuChiTietKhongConSuDung.Add(iddv.IdDichVuChiTiet);
                    }  
                }
            }
            //thực hiện xóa những idDichVuChiTiet nào không còn được sử dụng
            if (list_IdDichVuChiTietKhongConSuDung != null)
            {
                foreach (var iddv in list_IdDichVuChiTietKhongConSuDung)
                {
                    var XoaDichVu = _dichVuChiTietRepositories.XoaDichVuChiTiet(iddv);
                }
            }
            }
            catch (Exception ex) {
                if(ex != null)
                {
                    return BadRequest(ex.Message);
                }
               
            }
            return Ok("Sửa dịch vụ thành công");
        }
    }
}