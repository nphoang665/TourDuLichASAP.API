using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatTourController : ControllerBase
    {
        private readonly IDatTourRepositories _datTourRepositories;
        private readonly IDichVuChiTietRepositories _dichVuChiTietRepositories;
        private readonly IKhachHangRepositories _khachHangRepositories;

        public DatTourController(IDatTourRepositories datTourRepositories,IKhachHangRepositories khachHangRepositories,IDichVuChiTietRepositories dichVuChiTietRepositories)
        {
            _datTourRepositories = datTourRepositories;
            _dichVuChiTietRepositories = dichVuChiTietRepositories;
            _khachHangRepositories = khachHangRepositories;
        }

        [HttpPost]
        [Authorize(Roles = "Nhân viên")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDatTour([FromBody] CreateDatTourRequestDto request)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idDatTour = "DT" + randomValue.ToString("D4");
            var khachHang = await _datTourRepositories.GetkhachHangById(request.IdKhachHang);
            var nhanVien = await _datTourRepositories.GetNhanVienById(request.IdNhanVien);
            var tourDuLich = await _datTourRepositories.GetTourDuLichById(request.IdTour);
            var datTour = new DatTour
            {
                IdDatTour = idDatTour,
                IdKhachHang = request.IdKhachHang,
                IdTour = request.IdDatTour,
                SoLuongNguoiLon = request.SoLuongNguoiLon,
                SoLuongTreEm = request.SoLuongTreEm,
                GhiChu = request.GhiChu,
                IdNhanVien = request.IdNhanVien,
                ThoiGianDatTour = request.ThoiGianDatTour,
                TinhTrang = request.TinhTrang,
                KhachHang = khachHang,
                NhanVien = nhanVien,
                TourDuLich = tourDuLich
            };

            datTour = await _datTourRepositories.CreateAsync(datTour);
            var response = new DatTourDto
            {
                IdDatTour = idDatTour,
                IdKhachHang = request.IdKhachHang,
                IdTour = request.IdDatTour,
                SoLuongNguoiLon = request.SoLuongNguoiLon,
                SoLuongTreEm = request.SoLuongTreEm,
                GhiChu = request.GhiChu,
                IdNhanVien = request.IdNhanVien,
                ThoiGianDatTour = request.ThoiGianDatTour,
                TinhTrang = request.TinhTrang,
            };
            return Ok(response);
        }

        [HttpPost("/DatTourChoKhachHang")]
        [Authorize(Roles = "Nhân viên")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DatTourChoKhachHang([FromBody] CreateDatTourRequestFromKhachHangDto request)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idDatTour = "DT" + randomValue.ToString("D4");

            
            int randomValue1 = random.Next(1000);
            string idKhachHang = "KH" + randomValue1.ToString("D4");

            
           

            var khachHang = new KhachHang
            {
                IdKhachHang = idKhachHang,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                DiaChi = request.DiaChi,
                CCCD = request.CCCD,
                NgaySinh = request.NgaySinh,
                GioiTinh = request.GioiTinh,
                Email = request.Email,
                TinhTrang = request.TinhTrangKhachHang,
                MatKhau = null,
                NgayDangKy = request.NgayDangKy,
            };
            khachHang =await _khachHangRepositories.CreateAsync(khachHang);
            var datTour = new DatTour
            {
                IdDatTour = idDatTour,
                IdKhachHang = khachHang.IdKhachHang,
                IdTour = request.IdTour,
                SoLuongNguoiLon = request.SoLuongNguoiLon,
                SoLuongTreEm = request.SoLuongTreEm,
                GhiChu = null,
                IdNhanVien = null,
                ThoiGianDatTour = request.ThoiGianDatTour,
                TinhTrang = request.TinhTrangDatTour,
                };
            datTour = await _datTourRepositories.CreateAsync(datTour);

            if(request.DichVuChiTiet != null)
            {
                foreach (var item in request.DichVuChiTiet)
                {
                    int randomValue2 = random.Next(1000);
                    string idDichVuChiTiet = "DC" + randomValue2.ToString("D4");
                    var dichVuChiTiet = new DichVuChiTiet
                    {
                        IdDichVuChiTiet = idDichVuChiTiet,
                        IdDatTour = datTour.IdDatTour,
                        IdKhachHang = khachHang.IdKhachHang,
                        IdDichVu = item.IdDichVu,
                        ThoiGianDichVu = request.NgayDangKy,
                        SoLuong = item.SoLuong,

                    };
                    dichVuChiTiet = await _dichVuChiTietRepositories.ThemDichVuChiTiet(dichVuChiTiet);
                }
            }



            return BadRequest(request);
        }

        [HttpGet]
        [Authorize(Roles = "Nhân viên")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllDatTour()
        {
            
            var datTours = await _datTourRepositories.GetAllAsync();

            var response = new List<DatTourDto>();
            foreach (var datTour in datTours)
            {
                response.Add(new DatTourDto()
                {
                    IdDatTour = datTour.IdDatTour,
                    IdKhachHang = datTour.IdKhachHang,
                    IdTour = datTour.IdTour,
                    SoLuongNguoiLon = datTour.SoLuongNguoiLon,
                    SoLuongTreEm = datTour.SoLuongTreEm,
                    GhiChu = datTour.GhiChu,
                    IdNhanVien = datTour.IdNhanVien,
                    ThoiGianDatTour = datTour.ThoiGianDatTour,
                    TinhTrang = datTour.TinhTrang,
                    KhachHang = datTour.KhachHang,
                    NhanVien = datTour.NhanVien.TenNhanVien,
                    TourDuLich = datTour.TourDuLich.TenTour
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Nhân viên")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDatTourById(string id)
        {
            var datTour = await _datTourRepositories.GetByIdAsync(id);
            if(datTour is null)
            {
                return NotFound();
            }

            var response = new DatTourDto
            {
                IdDatTour = datTour.IdDatTour,
                IdKhachHang = datTour.IdKhachHang,
                IdTour = datTour.IdTour,
                SoLuongNguoiLon = datTour.SoLuongNguoiLon,
                SoLuongTreEm = datTour.SoLuongTreEm,
                GhiChu = datTour.GhiChu,
                IdNhanVien = datTour.IdNhanVien,
                ThoiGianDatTour = datTour.ThoiGianDatTour,
                TinhTrang = datTour.TinhTrang,
                KhachHang = datTour.KhachHang,
                NhanVien = datTour.NhanVien.TenNhanVien,
                TourDuLich = datTour.TourDuLich.TenTour
            };

            return Ok(response);
        }
        [HttpGet("/timkiemdattourtheoidtour/{idTour}")]
        [Authorize(Roles = "Nhân viên")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetDatTourByIdTour(string idTour)
        {
            var datTour = await _datTourRepositories.GetTourDuLichByIdTour(idTour);
            if (datTour is null)
            {
                return NotFound();
            }
            var response = new List<DatTourDto>();
            {
                foreach (var dattour in datTour)
                {
                    response.Add(new DatTourDto()
                    {
                        IdDatTour = dattour.IdDatTour,
                        IdKhachHang = dattour.IdKhachHang,
                        IdTour = dattour.IdTour,
                        SoLuongNguoiLon = dattour.SoLuongNguoiLon,
                        SoLuongTreEm = dattour.SoLuongTreEm,
                        GhiChu = dattour.GhiChu,
                        IdNhanVien = dattour.IdNhanVien,
                        ThoiGianDatTour = dattour.ThoiGianDatTour,
                        TinhTrang = dattour.TinhTrang,
                        KhachHang = dattour.KhachHang,
                        NhanVien = dattour.NhanVien !=null  ? dattour.NhanVien.TenNhanVien: null,
                        TourDuLich = dattour.TourDuLich.TenTour
                    });
                }

                return Ok(response);
            }
        }
        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Nhân viên")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDatTour(string id, UpdateDatTourRequestDto dto)
        {
            var khachHang = await _datTourRepositories.GetkhachHangById(dto.IdKhachHang);
            var nhanVien = await _datTourRepositories.GetNhanVienById(dto.IdNhanVien);
            var tourDuLich = await _datTourRepositories.GetTourDuLichById(dto.IdTour);
            var datTour = new DatTour
            {
                IdDatTour = id,
                IdKhachHang = dto.IdKhachHang,
                IdTour = dto.IdTour,
                SoLuongNguoiLon = dto.SoLuongNguoiLon,
                SoLuongTreEm = dto.SoLuongTreEm,
                GhiChu = dto.GhiChu,
                IdNhanVien = dto.IdNhanVien,
                ThoiGianDatTour = dto.ThoiGianDatTour,
                TinhTrang = dto.TinhTrang,
                KhachHang = khachHang,
                NhanVien = nhanVien,
                TourDuLich = tourDuLich
            };

           datTour = await _datTourRepositories.UpdateAsync(datTour);

            if(datTour == null)
            {
                return NotFound();
            }

            var response = new DatTourDto
            {
                IdDatTour = datTour.IdDatTour,
                IdKhachHang = datTour.IdKhachHang,
                IdTour = datTour.IdTour,
                SoLuongNguoiLon = datTour.SoLuongNguoiLon,
                SoLuongTreEm = datTour.SoLuongTreEm,
                GhiChu = datTour.GhiChu,
                IdNhanVien = datTour.IdNhanVien,
                ThoiGianDatTour = datTour.ThoiGianDatTour,
                TinhTrang = datTour.TinhTrang,
                KhachHang = datTour.KhachHang,
                NhanVien = datTour.NhanVien.TenNhanVien,
                TourDuLich = datTour.TourDuLich.TenTour
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Nhân viên")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDatTour(string id)
        {


            var deleteDatTour = await _datTourRepositories.DeleteAsync(id);
            if(deleteDatTour == null)
            {
                return NotFound();
            }

            var response = new DatTour
            {
                IdDatTour = id,
                IdKhachHang = deleteDatTour.IdKhachHang,
                IdTour = deleteDatTour.IdTour,
                SoLuongNguoiLon = deleteDatTour.SoLuongNguoiLon,
                SoLuongTreEm = deleteDatTour.SoLuongTreEm,
                GhiChu = deleteDatTour.GhiChu,
                IdNhanVien = deleteDatTour.IdNhanVien,
                ThoiGianDatTour = deleteDatTour.ThoiGianDatTour,
                TinhTrang = deleteDatTour.TinhTrang,
            };
            return Ok(response);
        }
    }
}
