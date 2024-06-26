﻿using Microsoft.EntityFrameworkCore;
using TourDuLichASAP.API.Data;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Repositories.Implementation
{
    public class DichVuChiTietRepositories : IDichVuChiTietRepositories
    {
        private readonly ApplicationDbContext _db;

        public DichVuChiTietRepositories(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<DichVuChiTiet> CapNhatDichVuChiTiet(DichVuChiTiet dichVuChiTiet)
        {
            var existingDichVuChiTiet = await _db.DICH_VU_CHI_TIET.FirstOrDefaultAsync(x => x.IdDichVuChiTiet == dichVuChiTiet.IdDichVuChiTiet);
            if (existingDichVuChiTiet == null)
            {
                return null;
            }
            _db.Entry(existingDichVuChiTiet).CurrentValues.SetValues(dichVuChiTiet);
            await _db.SaveChangesAsync();
            return dichVuChiTiet;


        }

        public async Task<IEnumerable<DichVuChiTiet>> GetAllAsync()
        {
            return await _db.DICH_VU_CHI_TIET.Include(x => x.KhachHang).Include(x => x.DichVu).Include(x => x.DatTour).Include(x => x.NhanVien).ToListAsync();
        }

        public async Task<DatTour> GetDatTourById(string idDatTour)
        {
            return await _db.DAT_TOUR.FindAsync(idDatTour);
        }

        public async Task<DichVu> GetDichVuById(string idDichVu)
        {
            return await _db.DICH_VU.FirstAsync(dv => dv.IdDichVu == idDichVu);
        }

        public async Task<IEnumerable<DichVuChiTiet>> GetDichVuChiTietById(string id)
        {
            return await _db.DICH_VU_CHI_TIET.Where(s => s.IdDatTour == id).Include(x =>x.DichVu).ToListAsync();


        }

        public async Task<KhachHang> GetkhachHangById(string idKhachHang)
        {
            return await _db.KHACH_HANG.FirstAsync(kh => kh.IdKhachHang == idKhachHang);
        }

        public async Task<NhanVien> GetNhanVienById(string idNhanVien)
        {
            return await _db.NHAN_VIEN.FirstAsync(nv => nv.IdNhanVien == idNhanVien);
        }

        //public async Task<DichVuChiTiet> SuaDichVuChiTiet(string id, DichVuChiTiet dichVuChiTiet)
        //{
        //    var existingDichVu = await _db.DICH_VU_CHI_TIET.FirstOrDefaultAsync(x => x.IdDichVuChiTiet == dichVuChiTiet.IdDichVuChiTiet);
        //    if (existingDichVu == null)
        //    {
        //        return null;
        //    }
        //    _db.Entry(existingDichVu).CurrentValues.SetValues(dichVuChiTiet);
        //    await _db.SaveChangesAsync();
        //    return dichVuChiTiet;
        //}

        public async Task<DichVuChiTiet> ThemDichVuChiTiet(DichVuChiTiet dichVuChiTiet)
        {
            await _db.DICH_VU_CHI_TIET.AddAsync(dichVuChiTiet);
            await _db.SaveChangesAsync();
            return dichVuChiTiet;
        }

        public async Task<DichVuChiTiet> XoaDichVuChiTiet(string id)
        {
            var existDichVuChiTiet =  _db.DICH_VU_CHI_TIET.FirstOrDefault(s => s.IdDichVuChiTiet == id);
            if (existDichVuChiTiet != null)
            {
                _db.DICH_VU_CHI_TIET.Remove(existDichVuChiTiet);
                _db.SaveChanges();
                 return existDichVuChiTiet;
            }
            else
            {
                return null;
            }
        }
        
    }
}
