using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class DanhGiaDto
    {
     
        public string IdDanhGia { get; set; }

    
        public string IdKhachHang { get; set; }

     
        public string IdTour { get; set; }

        public int DiemDanhGia { get; set; }

        public string NhanXet { get; set; } 

        public DateTime ThoiGianDanhGia { get; set; }
        public int Like {  get; set; }
        public int DisLike { get; set; }
        public KhachHang khachHang { get; set; }
    }
}
