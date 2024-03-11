using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class AnhDoiTac
    {
        [Key]
        public int IdAnhDoiTac { get; set; }

        [StringLength(6)]
        [ForeignKey("DoiTac")]
        public string IdDoiTac { get; set; }

        public string imageDoiTac { get; set; } // Consider changing the type based on actual data storage need

        [Column(TypeName = "Date")]
        public DateTime NgayThem { get; set; }

        public DoiTac DoiTac { get; set; }
    }
}
