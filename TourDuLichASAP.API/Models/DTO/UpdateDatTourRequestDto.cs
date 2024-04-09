namespace TourDuLichASAP.API.Models.DTO
{
    public class UpdateDatTourRequestDto
    {
        public string IdKhachHang { get; set; }
        public string IdTour { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public string? GhiChu { get; set; } // NTEXT in SQL Server is mapped to string in C#
        public string? IdNhanVien { get; set; }
        public DateTime ThoiGianDatTour { get; set; }
        public string TinhTrang { get; set; }
    }
}
