﻿using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Models.DTO
{
    public class CreateThanhToanRequestDto
    {
        public string IdThanhToan { get; set; }
        public string IdDatTour { get; set; }
        public string IdKhachHang { get; set; }
        public string IdNhanVien { get; set; }

        public int TongTienTour { get; set; }

        public int TongTienDichVu { get; set; }

        public int TongTien { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public string PhuongThucThanhToan { get; set; }
    }
}
