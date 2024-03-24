using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class ThemDanhGiaDto
    {
        public string IdDanhGia { get; set; }


        public string IdKhachHang { get; set; }


        public string IdTour { get; set; }

        public int DiemDanhGia { get; set; }

        public string NhanXet { get; set; }

        public DateTime ThoiGianDanhGia { get; set; }
      
    }
}
