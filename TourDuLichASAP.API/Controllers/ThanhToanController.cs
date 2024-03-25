using Azure.Core;
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
    public class ThanhToanController : ControllerBase
    {
        private readonly IThanhToanRepositories _thanhToanRepositories;

        public ThanhToanController(IThanhToanRepositories thanhToanRepositories)
        {
            _thanhToanRepositories = thanhToanRepositories;
        }

        [HttpGet]
        //[Authorize(Roles = "Nhân viên")]
        //[Authorize(Roles = "Admin")]
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
                    NhanVien = thanhToan.NhanVien
                });
            }
            return Ok(response);
        }

        [HttpPost]
        //[Authorize(Roles = "Nhân viên")]
        //[Authorize(Roles = "Admin")]
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
                TinhTrang = "Chưa thanh toán",
                NgayThanhToan = DateTime.Now,
                PhuongThucThanhToan = requestDto.PhuongThucThanhToan,
                DatTour = datTour,
                KhachHang = khachHang,
                NhanVien = nhanVien
            };

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
        //[Authorize(Roles = "Nhân viên")]
        //[Authorize(Roles = "Admin")]
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
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        //[Authorize(Roles = "Nhân viên")]
        //[Authorize(Roles = "Admin")]
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
        [HttpDelete]
        [Route("{id}")]
        //[Authorize(Roles = "Nhân viên")]
        //[Authorize(Roles = "Admin")]
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
