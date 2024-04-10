using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.DTO;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrangChuController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public TrangChuController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet("DoanhThuTheoThang")]
        public async Task<IActionResult> GetDoanhThuTheoThang()
        {
            var doanhThuTheoThang = await (from thanhToan in _db.THANH_TOAN
                                           group thanhToan by new { year = thanhToan.NgayThanhToan.Year, month = thanhToan.NgayThanhToan.Month } into g
                                           select new DoanhThuTheoNamDTO
                                           {
                                               Thang = g.Key.month.ToString() + "/" + g.Key.year.ToString(),
                                               DoanhThuThang = g.Sum(tt => tt.TongTien)
                                           }).ToListAsync();

            return Ok(doanhThuTheoThang);
        }
        [HttpGet("TiLeDatHuy")]
        public async Task<IActionResult> GetTiLe()
        {
            var soTourTheoTinhTrang = await (from tour in _db.DAT_TOUR
                                             group tour by tour.TinhTrang into g
                                             select new
                                             {
                                                 TinhTrang = g.Key,
                                                 SoTour = g.Count()
                                             }).ToListAsync();

            var daThanhToan = soTourTheoTinhTrang.FirstOrDefault(tt => tt.TinhTrang == "Đã thanh toán")?.SoTour ?? 0;
            var daDuyet = soTourTheoTinhTrang.FirstOrDefault(tt => tt.TinhTrang == "Đã được duyệt")?.SoTour ?? 0;
            var daTuChoi = soTourTheoTinhTrang.FirstOrDefault(tt => tt.TinhTrang == "Đã từ chối")?.SoTour ?? 0;
            var dangDoiDuyet = soTourTheoTinhTrang.FirstOrDefault(tt => tt.TinhTrang == "Đang đợi duyệt")?.SoTour ?? 0;

            return Ok(new { daThanhToan, daDuyet, daTuChoi, dangDoiDuyet });
        }
        [HttpGet("DichVuDaDat")]
        public async Task<IActionResult> DichVuDaDat()
        {
            var dichVuDaDat = from dvct in _db.DICH_VU_CHI_TIET
                              join dv in _db.DICH_VU on dvct.IdDichVu equals dv.IdDichVu
                              group dvct by new { dvct.IdDichVu, dv.TenDichVu, dv.GiaTien } into g
                              select new DichVuDaDat
                              {
                                  TenDichVu = g.Key.TenDichVu,
                                  soLuong = g.Sum(dvct => dvct.SoLuong),
                                  tongTien = g.Sum(dvct => dvct.SoLuong * g.Key.GiaTien)
                              };
            return Ok(dichVuDaDat);
        }
        [HttpGet("TourDaDat")]
        public async Task<IActionResult> TourDaDat()
        {
            var tourDaDat = from datTour in _db.DAT_TOUR
                            join tour in _db.TOUR_DU_LICH on datTour.IdTour equals tour.IdTour
                            group datTour by new { datTour.IdTour, tour.TenTour, tour.GiaNguoiLon, tour.GiaTreEm } into g
                            select new TourDaDat
                            {
                                TenTour = g.Key.TenTour,
                                SoLuong = g.Sum(dt => dt.SoLuongNguoiLon + dt.SoLuongTreEm),
                                TongTien = g.Sum(dt => dt.SoLuongNguoiLon * g.Key.GiaNguoiLon + dt.SoLuongTreEm * g.Key.GiaTreEm)
                            };
            return Ok(tourDaDat);
        }
    }
}
