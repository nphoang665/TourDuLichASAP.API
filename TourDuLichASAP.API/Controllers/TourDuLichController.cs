using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourDuLichController : ControllerBase
    {
        private readonly ITourDuLichRepositories _tourDuLichRepositories;

        public TourDuLichController(ITourDuLichRepositories tourDuLichRepositories)
        {
            _tourDuLichRepositories = tourDuLichRepositories;
        }

        [HttpPost]
        public async Task <IActionResult> CreateTourDuLich([FromBody] CreateTourDuLichRequestDto requestDto)
        {
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idTour = "TDL" + randomValue.ToString("D3");

            //convert
            var tourDuLich = new TourDuLich
            {
                IdTour = idTour,
                TenTour = requestDto.TenTour,
                LoaiTour = requestDto.LoaiTour,
                PhuongTienDiChuyen = requestDto.PhuongTienDiChuyen,
                MoTa = requestDto.MoTa,
                SoLuongNguoiLon = requestDto.SoLuongNguoiLon,
                SoLuongTreEm = requestDto.SoLuongTreEm,
                ThoiGianBatDau = requestDto.ThoiGianBatDau,
                ThoiGianKetThuc = requestDto.ThoiGianKetThuc,
                NoiKhoiHanh = requestDto.NoiKhoiHanh,
                SoChoConNhan = requestDto.SoChoConNhan,
                IdDoiTac = requestDto.IdDoiTac,
                GiaTreEm = requestDto.GiaTreEm,
                GiaNguoiLon = requestDto.GiaNguoiLon,
                NgayThem = requestDto.NgayThem,
                DichVuDiKem = requestDto.DichVuDiKem,
                TinhTrang = requestDto.TinhTrang,
            };


            var doiTac = await _tourDuLichRepositories.GetDoiTacAsync(requestDto.IdDoiTac);
            tourDuLich.DoiTac = doiTac;
            tourDuLich = await _tourDuLichRepositories.CreateAsync(tourDuLich);

            var response = new TourDuLichDto
            {
                IdTour = idTour,
                TenTour = requestDto.TenTour,
                LoaiTour = requestDto.LoaiTour,
                PhuongTienDiChuyen = requestDto.PhuongTienDiChuyen,
                MoTa = requestDto.MoTa,
                SoLuongNguoiLon = requestDto.SoLuongNguoiLon,
                SoLuongTreEm = requestDto.SoLuongTreEm,
                ThoiGianBatDau = requestDto.ThoiGianBatDau,
                ThoiGianKetThuc = requestDto.ThoiGianKetThuc,
                NoiKhoiHanh = requestDto.NoiKhoiHanh,
                SoChoConNhan = requestDto.SoChoConNhan,
                IdDoiTac = requestDto.IdDoiTac,
                GiaTreEm = requestDto.GiaTreEm,
                GiaNguoiLon = requestDto.GiaNguoiLon,
                NgayThem = requestDto.NgayThem,
                DichVuDiKem = requestDto.DichVuDiKem,
                TinhTrang = requestDto.TinhTrang,
                TenDoiTac = doiTac.TenDoiTac,
                EmailDoiTac = doiTac.Email,
                SoDienThoaiDoiTac = doiTac.SoDienThoai
            };

            return Ok(response);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllTourDuLich()
        {
            var tourDuLichs = await _tourDuLichRepositories.GetAllAsync();

            //convert
            var response = new List<TourDuLichDto>();
            foreach (var tourDuLich in tourDuLichs)
            {
                response.Add(new TourDuLichDto
                {
                    IdTour = tourDuLich.IdTour,
                    TenTour = tourDuLich.TenTour,
                    LoaiTour = tourDuLich.LoaiTour,
                    PhuongTienDiChuyen = tourDuLich.PhuongTienDiChuyen,
                    MoTa = tourDuLich.MoTa,
                    SoLuongNguoiLon = tourDuLich.SoLuongNguoiLon,
                    SoLuongTreEm = tourDuLich.SoLuongTreEm,
                    ThoiGianBatDau = tourDuLich.ThoiGianBatDau,
                    ThoiGianKetThuc = tourDuLich.ThoiGianKetThuc,
                    NoiKhoiHanh = tourDuLich.NoiKhoiHanh,
                    SoChoConNhan = tourDuLich.SoChoConNhan,
                    IdDoiTac = tourDuLich.IdDoiTac,
                    GiaTreEm = tourDuLich.GiaTreEm,
                    GiaNguoiLon = tourDuLich.GiaNguoiLon,
                    NgayThem = tourDuLich.NgayThem,
                    DichVuDiKem = tourDuLich.DichVuDiKem,
                    TinhTrang = tourDuLich.TinhTrang,
                    TenDoiTac = tourDuLich.DoiTac.TenDoiTac,
                    EmailDoiTac = tourDuLich.DoiTac.Email,
                    SoDienThoaiDoiTac = tourDuLich.DoiTac.SoDienThoai
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTourDuLichById(string id)
        {
            var tourDuLich = await _tourDuLichRepositories.GetByIdAsync(id);
            if(tourDuLich is null)
            {
                return NotFound();
            }

            var response = new TourDuLichDto
            {
                IdTour = tourDuLich.IdTour,
                TenTour = tourDuLich.TenTour,
                LoaiTour = tourDuLich.LoaiTour,
                PhuongTienDiChuyen = tourDuLich.PhuongTienDiChuyen,
                MoTa = tourDuLich.MoTa,
                SoLuongNguoiLon = tourDuLich.SoLuongNguoiLon,
                SoLuongTreEm = tourDuLich.SoLuongTreEm,
                ThoiGianBatDau = tourDuLich.ThoiGianBatDau,
                ThoiGianKetThuc = tourDuLich.ThoiGianKetThuc,
                NoiKhoiHanh = tourDuLich.NoiKhoiHanh,
                SoChoConNhan = tourDuLich.SoChoConNhan,
                IdDoiTac = tourDuLich.IdDoiTac,
                GiaTreEm = tourDuLich.GiaTreEm,
                GiaNguoiLon = tourDuLich.GiaNguoiLon,
                NgayThem = tourDuLich.NgayThem,
                DichVuDiKem = tourDuLich.DichVuDiKem,
                TinhTrang = tourDuLich.TinhTrang,
                TenDoiTac = tourDuLich.DoiTac.TenDoiTac,
                EmailDoiTac = tourDuLich.DoiTac.Email,
                SoDienThoaiDoiTac = tourDuLich.DoiTac.SoDienThoai
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTourDuLichById(string id, UpdateTourDuLichRequestDto dto)
        {
            var tourDuLich = new TourDuLich
            { 
                IdTour = id,
                TenTour = dto.TenTour,
                LoaiTour = dto.LoaiTour,
                PhuongTienDiChuyen = dto.PhuongTienDiChuyen,
                MoTa = dto.MoTa,
                SoLuongNguoiLon = dto.SoLuongNguoiLon,
                SoLuongTreEm = dto.SoLuongTreEm,
                ThoiGianBatDau = dto.ThoiGianBatDau,
                ThoiGianKetThuc = dto.ThoiGianKetThuc,
                NoiKhoiHanh = dto.NoiKhoiHanh,
                SoChoConNhan = dto.SoChoConNhan,
                IdDoiTac = dto.IdDoiTac,
                GiaTreEm = dto.GiaTreEm,
                GiaNguoiLon = dto.GiaNguoiLon,
                NgayThem = dto.NgayThem,
                DichVuDiKem = dto.DichVuDiKem,
                TinhTrang = dto.TinhTrang,
            };

            var doiTac = await _tourDuLichRepositories.GetDoiTacAsync(dto.IdDoiTac);
            tourDuLich.DoiTac = doiTac;
            var updateTourDuLich = await _tourDuLichRepositories.UpdateAsync(tourDuLich);

            if(updateTourDuLich == null)
            {
                return NotFound();
            }

            var response = new TourDuLichDto
            {
                IdTour = tourDuLich.IdTour,
                TenTour = tourDuLich.TenTour,
                LoaiTour = tourDuLich.LoaiTour,
                PhuongTienDiChuyen = tourDuLich.PhuongTienDiChuyen,
                MoTa = tourDuLich.MoTa,
                SoLuongNguoiLon = tourDuLich.SoLuongNguoiLon,
                SoLuongTreEm = tourDuLich.SoLuongTreEm,
                ThoiGianBatDau = tourDuLich.ThoiGianBatDau,
                ThoiGianKetThuc = tourDuLich.ThoiGianKetThuc,
                NoiKhoiHanh = tourDuLich.NoiKhoiHanh,
                SoChoConNhan = tourDuLich.SoChoConNhan,
                IdDoiTac = tourDuLich.IdDoiTac,
                GiaTreEm = tourDuLich.GiaTreEm,
                GiaNguoiLon = tourDuLich.GiaNguoiLon,
                NgayThem = tourDuLich.NgayThem,
                DichVuDiKem = tourDuLich.DichVuDiKem,
                TinhTrang = tourDuLich.TinhTrang,
                TenDoiTac = tourDuLich.DoiTac.TenDoiTac,
                EmailDoiTac = tourDuLich.DoiTac.Email,
                SoDienThoaiDoiTac = tourDuLich.DoiTac.SoDienThoai
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTourDuLich(string id)
        {
            var deleteTourDuLich = await _tourDuLichRepositories.DeleteAsync(id);
            if(deleteTourDuLich == null)
            {
                return NotFound();
            }

            var response = new TourDuLich
            {
                IdTour = id,
                TenTour = deleteTourDuLich.TenTour,
                LoaiTour = deleteTourDuLich.LoaiTour,
                PhuongTienDiChuyen = deleteTourDuLich.PhuongTienDiChuyen,
                MoTa = deleteTourDuLich.MoTa,
                SoLuongNguoiLon = deleteTourDuLich.SoLuongNguoiLon,
                SoLuongTreEm = deleteTourDuLich.SoLuongTreEm,
                ThoiGianBatDau = deleteTourDuLich.ThoiGianBatDau,
                ThoiGianKetThuc = deleteTourDuLich.ThoiGianKetThuc,
                NoiKhoiHanh = deleteTourDuLich.NoiKhoiHanh,
                SoChoConNhan = deleteTourDuLich.SoChoConNhan,
                IdDoiTac = deleteTourDuLich.IdDoiTac,
                GiaTreEm = deleteTourDuLich.GiaTreEm,
                GiaNguoiLon = deleteTourDuLich.GiaNguoiLon,
                NgayThem = deleteTourDuLich.NgayThem,
                DichVuDiKem = deleteTourDuLich.DichVuDiKem,
                TinhTrang = deleteTourDuLich.TinhTrang,
            };
            return Ok(response);
        }
    }
}
