using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class DoiTacDto
    {
   
        public string IdDoiTac { get; set; }

    
        public string TenDoiTac { get; set; }

      
        public string Email { get; set; }


        public string SoDienThoai { get; set; }

      
        public string DiaChi { get; set; }

        public float? DanhGiaApp { get; set; }

  
        public string? MoTa { get; set; }

      
        public DateTime NgayDangKy { get; set; }

        public string TinhTrang { get; set; }

       
    }
}
