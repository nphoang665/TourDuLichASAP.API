using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.DTO
{
    public class UpdateTourDuLichRequestDto
    {
        public string TenTour { get; set; }

        public string LoaiTour { get; set; }

        public string PhuongTienDiChuyen { get; set; }

        public string MoTa { get; set; }

        public int SoLuongNguoiLon { get; set; }


        public int SoLuongTreEm { get; set; }

        public DateTime ThoiGianBatDau { get; set; }

        public DateTime ThoiGianKetThuc { get; set; }

        public string NoiKhoiHanh { get; set; }

        public int SoChoConNhan { get; set; }

        public string IdDoiTac { get; set; }

        public int GiaTreEm { get; set; }

        public int GiaNguoiLon { get; set; }

        public DateTime NgayThem { get; set; }

        public string? DichVuDiKem { get; set; }
        public string TinhTrang { get; set; }

        public string[] AnhTourDb { get; set; }
        public string[] AnhTourBrowse { get; set; }

      

    }
}
