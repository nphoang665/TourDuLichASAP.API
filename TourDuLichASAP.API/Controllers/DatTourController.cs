using Azure.Core;
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

        public DatTourController(IDatTourRepositories datTourRepositories)
        {
            _datTourRepositories = datTourRepositories;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDatTour([FromBody] CreateDatTourRequestDto request)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idDatTour = "DT" + randomValue.ToString("D4");
            var khachHang = await _datTourRepositories.GetkhachHangById(request.IdKhachHang);
            var nhanVien = await _datTourRepositories.GetNhanVienById(request.IdNhanVien);
            var tourDuLich = await _datTourRepositories.GetTourDuLichById(request.IdTour);
            //if (request.ImgSelected != null)
            //{
            //    // Tạo thư mục 'uploads' nếu nó chưa tồn tại
            //    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            //    if (!Directory.Exists(folderPath))
            //    {
            //        Directory.CreateDirectory(folderPath);
            //    }

            //    for (int i = 0; i < request.ImgSelected.Length; i++)
            //    {
            //        // Tách chuỗi Base64 và loại media
            //        var parts = request.ImgSelected[i].Split(',');
            //        string mediaType = parts[0]; // Ví dụ: "data:image/jpeg;base64"
            //        string base64 = parts[1];

            //        // Chuyển đổi chuỗi Base64 thành mảng byte
            //        byte[] imageBytes = Convert.FromBase64String(base64);

            //        // Xác định định dạng file từ loại media
            //        var format = mediaType.Split(';')[0].Split('/')[1]; // Ví dụ: "jpeg"

            //        // Tạo tên file duy nhất cho mỗi hình ảnh
            //        string fileName = $"image_{i}_{DateTime.Now.Ticks}.{format}";

            //        // Tạo đường dẫn đầy đủ cho file
            //        string filePath = Path.Combine(folderPath, fileName);

            //        // Ghi mảng byte vào file
            //        System.IO.File.WriteAllBytes(filePath, imageBytes);
            //    }

            //}
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

        [HttpGet]
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
                    KhachHang = datTour.KhachHang.TenKhachHang,
                    NhanVien = datTour.NhanVien.TenNhanVien,
                    TourDuLich = datTour.TourDuLich.TenTour
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
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
                KhachHang = datTour.KhachHang.TenKhachHang,
                NhanVien = datTour.NhanVien.TenNhanVien,
                TourDuLich = datTour.TourDuLich.TenTour
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
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

            var updateDatTour = await _datTourRepositories.UpdateAsync(datTour);

            if(updateDatTour == null)
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
                KhachHang = datTour.KhachHang.TenKhachHang,
                NhanVien = datTour.NhanVien.TenNhanVien,
                TourDuLich = datTour.TourDuLich.TenTour
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
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
