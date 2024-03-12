using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class AnhTourDto
    {
     
        public int IdAnhTour { get; set; }

     
        public string IdTour { get; set; }

        public string ImgTour { get; set; } 

        public DateTime NgayThem { get; set; }
        public string TenTour { get; set; }
        
    }
}
