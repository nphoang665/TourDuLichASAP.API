﻿namespace TourDuLichASAP.API.Models.DTO
{
    public class CreateDichVuRequestDto
    {
        public string IdDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public int GiaTien { get; set; }
        public string TinhTrang { get; set; }
        public TimeOnly GioBatDau { get; set; }
        public TimeOnly GioKetThuc { get; set; }
        public DateTime NgayThem { get; set; }
    }
}
