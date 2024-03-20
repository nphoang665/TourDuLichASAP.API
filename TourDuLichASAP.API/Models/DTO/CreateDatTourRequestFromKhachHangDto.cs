using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class CreateDatTourRequestFromKhachHangDto
    {
        //phần dành cho đặt tour
        public string IdDatTour { get; set; }
        
        public string IdTour { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public DateTime ThoiGianDatTour { get; set; }
        public string TinhTrangDatTour { get; set; }
        //phần dành cho khách hàng
        public string IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string CCCD { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string TinhTrangKhachHang { get; set; }
        public DateTime NgayDangKy { get; set; }

        //phần dành cho dịch vụ chi tiết
       public List<DichVuChiTiet1> DichVuChiTiet { get; set; }
       
    }
    public class DichVuChiTiet1()
    {
        public string IdDichVuChiTiet { get; set; }
        public string IdDichVu { get; set; }
        public DateTime ThoiGianDichVu { get; set; }
        public int SoLuong { get; set; }
    }
}
