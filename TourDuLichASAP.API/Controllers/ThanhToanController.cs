using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Implementation;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhToanController : ControllerBase
    {
        private readonly IThanhToanRepositories _thanhToanRepositories;

        private readonly ApplicationDbContext _db;
        
        public ThanhToanController(IThanhToanRepositories thanhToanRepositories,ApplicationDbContext db)
        {
            _thanhToanRepositories = thanhToanRepositories;
            _db=db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllThanhToan()
        {
            var thanhToans = await _thanhToanRepositories.GetAllAsync();

            var response = new List<ThanhToanDto>();
            foreach(var thanhToan in thanhToans)
            {
                response.Add(new ThanhToanDto
                {
                    IdThanhToan = thanhToan.IdThanhToan,
                    IdDatTour = thanhToan.IdDatTour,
                    IdKhachHang = thanhToan.IdKhachHang,
                    IdNhanVien = thanhToan.IdNhanVien,
                    TongTienTour = thanhToan.TongTienTour,
                    TongTienDichVu = thanhToan.TongTienDichVu,
                    TongTien = thanhToan.TongTien,
                    TinhTrang = thanhToan.TinhTrang,
                    NgayThanhToan = thanhToan.NgayThanhToan,
                    PhuongThucThanhToan = thanhToan.PhuongThucThanhToan,
                    DatTour = thanhToan.DatTour,
                    KhachHang = thanhToan.KhachHang,
                 
                    
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateThanhToan([FromBody] CreateThanhToanRequestDto requestDto)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idTour = "TT" + randomValue.ToString("D4");
            var khachHang = await _thanhToanRepositories.GetKhachHangById(requestDto.IdKhachHang);
            var nhanVien = await _thanhToanRepositories.GetNhanVienById(requestDto.IdNhanVien);
            var datTour = await _thanhToanRepositories.GetDatTourById(requestDto.IdDatTour);

            var thanhToan = new ThanhToan
            {
                IdThanhToan = idTour,
                IdDatTour = requestDto.IdDatTour,
                IdKhachHang = requestDto.IdKhachHang,
                IdNhanVien = requestDto.IdNhanVien,
                TongTienTour = requestDto.TongTienTour,
                TongTienDichVu = requestDto.TongTienDichVu,
                TongTien = requestDto.TongTien,
                TinhTrang = requestDto.PhuongThucThanhToan=="Trả trước" ? "Đã thanh toán" : "Chưa thanh toán",
                NgayThanhToan = DateTime.Now,
                PhuongThucThanhToan = requestDto.PhuongThucThanhToan,
                DatTour = datTour,
                KhachHang = khachHang,
                NhanVien = nhanVien
            };
            await Task.Delay(1000);

            thanhToan = await _thanhToanRepositories.CreateAsync(thanhToan);

            var response = new ThanhToanDto
            {
                IdThanhToan = thanhToan.IdThanhToan,
                IdDatTour = thanhToan.IdDatTour,
                IdKhachHang = thanhToan.IdKhachHang,
                IdNhanVien = thanhToan.IdNhanVien,
                TongTienTour = thanhToan.TongTienTour,
                TongTienDichVu = thanhToan.TongTienDichVu,
                TongTien = thanhToan.TongTien,
                TinhTrang = thanhToan.TinhTrang,
                NgayThanhToan = thanhToan.NgayThanhToan,
                PhuongThucThanhToan = thanhToan.PhuongThucThanhToan,
            };
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetThanhToanById(string id)
        {
            var thanhToan = await _thanhToanRepositories.GetByIdAsync(id);
            if (thanhToan == null)
            {
                return NotFound();
            }

            var response = new ThanhToanDto
            {
                IdThanhToan = thanhToan.IdThanhToan,
                IdDatTour = thanhToan.IdDatTour,
                IdKhachHang = thanhToan.IdKhachHang,
                IdNhanVien = thanhToan.IdNhanVien,
                TongTienTour = thanhToan.TongTienTour,
                TongTienDichVu = thanhToan.TongTienDichVu,
                TongTien = thanhToan.TongTien,
                TinhTrang = thanhToan.TinhTrang,
                NgayThanhToan = thanhToan.NgayThanhToan,
                PhuongThucThanhToan = thanhToan.PhuongThucThanhToan,
                KhachHang = thanhToan.KhachHang,
                NhanVien = thanhToan.NhanVien,
                DatTour = thanhToan.DatTour,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDatTour(string id,UpdateThanhToanRequestDto requestDto)
        {
            var khachHang = await _thanhToanRepositories.GetKhachHangById(requestDto.IdKhachHang);
            var nhanVien = await _thanhToanRepositories.GetNhanVienById(requestDto.IdNhanVien);
            var datTour = await _thanhToanRepositories.GetDatTourById(requestDto.IdDatTour);
            var thanhToan = new ThanhToan
            {
                IdThanhToan = id,
                IdDatTour = requestDto.IdDatTour,
                IdKhachHang = requestDto.IdKhachHang,
                IdNhanVien = requestDto.IdNhanVien,
                TongTienTour = requestDto.TongTienTour,
                TongTienDichVu = requestDto.TongTienDichVu,
                TongTien = requestDto.TongTien,
                TinhTrang = requestDto.TinhTrang,
                NgayThanhToan = requestDto.NgayThanhToan,
                PhuongThucThanhToan = requestDto.PhuongThucThanhToan,
                DatTour = datTour,
                KhachHang = khachHang,
                NhanVien = nhanVien
            };

            thanhToan = await _thanhToanRepositories.UpdateAsync(thanhToan);
            if (thanhToan == null)
            {
                return NotFound();
            }
            var response = new ThanhToanDto
            {
                IdThanhToan = thanhToan.IdThanhToan,
                IdDatTour = thanhToan.IdDatTour,
                IdKhachHang = thanhToan.IdKhachHang,
                IdNhanVien = thanhToan.IdNhanVien,
                TongTienTour = thanhToan.TongTienTour,
                TongTienDichVu = thanhToan.TongTienDichVu,
                TongTien = thanhToan.TongTien,
                TinhTrang = thanhToan.TinhTrang,
                NgayThanhToan = thanhToan.NgayThanhToan,
                PhuongThucThanhToan = thanhToan.PhuongThucThanhToan,
            };
            return Ok(response);
        }
        [HttpGet("GetThanhToanByIdDatTour/{id}")]
        public async Task<IActionResult> GetThanhToanByIdDatTour(string id)
        {
            // Tìm kiếm trong bảng THANH_TOAN với IdDatTour tương ứng
            var thanhToan = await _db.THANH_TOAN.FirstOrDefaultAsync(tt => tt.IdDatTour == id);

            // Nếu không tìm thấy kết quả phù hợp, trả về NotFound
            if (thanhToan == null)
            {
                return NotFound();
            }

            // Chuyển đổi đối tượng thanhToan thành DTO
            ThanhToanDto thanhToanDto = new ThanhToanDto
            {
                IdThanhToan = thanhToan.IdThanhToan,
                IdDatTour = thanhToan.IdDatTour,
                IdKhachHang = thanhToan.IdKhachHang,
                IdNhanVien = thanhToan.IdNhanVien,
                TongTienTour = thanhToan.TongTienTour,
                TongTienDichVu = thanhToan.TongTienDichVu,
                TongTien = thanhToan.TongTien,
                TinhTrang = thanhToan.TinhTrang,
                NgayThanhToan = thanhToan.NgayThanhToan,
                PhuongThucThanhToan = thanhToan.PhuongThucThanhToan
            };

            // Trả về kết quả
            return Ok(thanhToanDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteThanhToan(string id)
        {
            var deleteThanhToan = await _thanhToanRepositories.DeleteAsync(id);
            if (deleteThanhToan == null)
            {
                return NotFound();
            }
            var khachHang = await _thanhToanRepositories.GetKhachHangById(deleteThanhToan.IdKhachHang);
            var nhanVien = await _thanhToanRepositories.GetNhanVienById(deleteThanhToan.IdNhanVien);
            var datTour = await _thanhToanRepositories.GetDatTourById(deleteThanhToan.IdDatTour);
            var response = new ThanhToan
            {
                IdThanhToan = id,
                IdDatTour = deleteThanhToan.IdDatTour,
                IdKhachHang = deleteThanhToan.IdKhachHang,
                IdNhanVien = deleteThanhToan.IdNhanVien,
                TongTienTour = deleteThanhToan.TongTienTour,
                TongTienDichVu = deleteThanhToan.TongTienDichVu,
                TongTien = deleteThanhToan.TongTien,
                TinhTrang = deleteThanhToan.TinhTrang,
                NgayThanhToan = deleteThanhToan.NgayThanhToan,
                PhuongThucThanhToan = deleteThanhToan.PhuongThucThanhToan,
                DatTour = datTour,
                KhachHang = khachHang,
                NhanVien = nhanVien
            };
            return Ok(response);
        }
    }
}
