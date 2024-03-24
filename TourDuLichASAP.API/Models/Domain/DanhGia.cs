﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TourDuLichASAP.API.Models.Domain
{
    public class DanhGia
    {
        [Key]
        [StringLength(6)]
        public string IdDanhGia { get; set; }

        [Required]
        [StringLength(6)]
        public string IdKhachHang { get; set; }

        [StringLength(6)]
        public string? IdTour { get; set; }

        public int DiemDanhGia { get; set; }

        public string NhanXet { get; set; } 

        public DateTime ThoiGianDanhGia { get; set; }

        [ForeignKey("IdKhachHang")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("IdTour")]
        public virtual TourDuLich? TourDuLich { get; set; }
    }
}
