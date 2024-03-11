using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class AnhTour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnhTour { get; set; }

        [Required]
        [StringLength(6)]
        public string IdTour { get; set; }

        public string ImgTour { get; set; } // Assuming it stores URL or path to image

        [Column(TypeName = "Date")]
        public DateTime NgayThem { get; set; }

        [ForeignKey("IdTour")]
        public virtual TourDuLich TourDuLich { get; set; }
    }
}
