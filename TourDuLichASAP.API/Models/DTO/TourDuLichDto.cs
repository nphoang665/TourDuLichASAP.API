using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class TourDuLichDto
    {
        public string IdTour { get; set; }
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

        public string TenDoiTac { get; set; }
        public string EmailDoiTac { get; set; }
        public string SoDienThoaiDoiTac { get; set; }
    }
}
