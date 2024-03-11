﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TourDuLichASAP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DICH_VU",
                columns: table => new
                {
                    IdDichVu = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GiaTien = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThem = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DICH_VU", x => x.IdDichVu);
                });

            migrationBuilder.CreateTable(
                name: "DOI_TAC",
                columns: table => new
                {
                    IdDoiTac = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TenDoiTac = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DanhGiaApp = table.Column<float>(type: "real", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "Date", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOI_TAC", x => x.IdDoiTac);
                });

            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    IdKhachHang = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "Date", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACH_HANG", x => x.IdKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "NHAN_VIEN",
                columns: table => new
                {
                    IdNhanVien = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "Date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "Date", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NgayVaoLam = table.Column<DateTime>(type: "Date", nullable: false),
                    AnhNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHAN_VIEN", x => x.IdNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "ANH_DOI_TAC",
                columns: table => new
                {
                    IdAnhDoiTac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDoiTac = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    imageDoiTac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThem = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANH_DOI_TAC", x => x.IdAnhDoiTac);
                    table.ForeignKey(
                        name: "FK_ANH_DOI_TAC_DOI_TAC_IdDoiTac",
                        column: x => x.IdDoiTac,
                        principalTable: "DOI_TAC",
                        principalColumn: "IdDoiTac",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TOUR_DU_LICH",
                columns: table => new
                {
                    IdTour = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TenTour = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiTour = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhuongTienDiChuyen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongNguoiLon = table.Column<int>(type: "int", nullable: false),
                    SoLuongTreEm = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiKhoiHanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoChoConNhan = table.Column<int>(type: "int", nullable: false),
                    IdDoiTac = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    GiaTreEm = table.Column<int>(type: "int", nullable: false),
                    GiaNguoiLon = table.Column<int>(type: "int", nullable: false),
                    NgayThem = table.Column<DateTime>(type: "Date", nullable: false),
                    DichVuDiKem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOUR_DU_LICH", x => x.IdTour);
                    table.ForeignKey(
                        name: "FK_TOUR_DU_LICH_DOI_TAC_IdDoiTac",
                        column: x => x.IdDoiTac,
                        principalTable: "DOI_TAC",
                        principalColumn: "IdDoiTac",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ANH_TOUR",
                columns: table => new
                {
                    IdAnhTour = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTour = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ImgTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayThem = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANH_TOUR", x => x.IdAnhTour);
                    table.ForeignKey(
                        name: "FK_ANH_TOUR_TOUR_DU_LICH_IdTour",
                        column: x => x.IdTour,
                        principalTable: "TOUR_DU_LICH",
                        principalColumn: "IdTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DANH_GIA",
                columns: table => new
                {
                    IdDanhGia = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdKhachHang = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdTour = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    DiemDanhGia = table.Column<int>(type: "int", nullable: false),
                    NhanXet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianDanhGia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANH_GIA", x => x.IdDanhGia);
                    table.ForeignKey(
                        name: "FK_DANH_GIA_KHACH_HANG_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "IdKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DANH_GIA_TOUR_DU_LICH_IdTour",
                        column: x => x.IdTour,
                        principalTable: "TOUR_DU_LICH",
                        principalColumn: "IdTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DAT_TOUR",
                columns: table => new
                {
                    IdDatTour = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdKhachHang = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdTour = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    SoLuongNguoiLon = table.Column<int>(type: "int", nullable: false),
                    SoLuongTreEm = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNhanVien = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ThoiGianDatTour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAT_TOUR", x => x.IdDatTour);
                    table.ForeignKey(
                        name: "FK_DAT_TOUR_KHACH_HANG_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "IdKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DAT_TOUR_NHAN_VIEN_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DAT_TOUR_TOUR_DU_LICH_IdTour",
                        column: x => x.IdTour,
                        principalTable: "TOUR_DU_LICH",
                        principalColumn: "IdTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DICH_VU_CHI_TIET",
                columns: table => new
                {
                    IdDichVuChiTiet = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdDichVu = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdKhachHang = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdDatTour = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdNhanVien = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ThoiGianDichVu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DICH_VU_CHI_TIET", x => x.IdDichVuChiTiet);
                    table.ForeignKey(
                        name: "FK_DICH_VU_CHI_TIET_DAT_TOUR_IdDatTour",
                        column: x => x.IdDatTour,
                        principalTable: "DAT_TOUR",
                        principalColumn: "IdDatTour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DICH_VU_CHI_TIET_DICH_VU_IdDichVu",
                        column: x => x.IdDichVu,
                        principalTable: "DICH_VU",
                        principalColumn: "IdDichVu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DICH_VU_CHI_TIET_KHACH_HANG_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "IdKhachHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DICH_VU_CHI_TIET_NHAN_VIEN_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THANH_TOAN",
                columns: table => new
                {
                    IdThanhToan = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdDichVuChiTiet = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdDatTour = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdKhachHang = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    IdNhanVien = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    TongTienTour = table.Column<int>(type: "int", nullable: false),
                    TongTienDichVu = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THANH_TOAN", x => x.IdThanhToan);
                    table.ForeignKey(
                        name: "FK_THANH_TOAN_DAT_TOUR_IdDatTour",
                        column: x => x.IdDatTour,
                        principalTable: "DAT_TOUR",
                        principalColumn: "IdDatTour",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THANH_TOAN_DICH_VU_CHI_TIET_IdDichVuChiTiet",
                        column: x => x.IdDichVuChiTiet,
                        principalTable: "DICH_VU_CHI_TIET",
                        principalColumn: "IdDichVuChiTiet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THANH_TOAN_KHACH_HANG_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "IdKhachHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THANH_TOAN_NHAN_VIEN_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "IdNhanVien",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DOI_TAC",
                columns: new[] { "IdDoiTac", "DanhGiaApp", "DiaChi", "Email", "MoTa", "NgayDangKy", "SoDienThoai", "TenDoiTac", "TinhTrang" },
                values: new object[,]
                {
                    { "DT0001", 4.5f, "01-03 Phan Chu Trinh, Tp. Buôn Ma Thuột, Đắk Lắk", "sales@daklaktourist.com.vn", "Công ty chuyên về kinh doanh khách sạn, nhà hàng, khu du lịch tại thành phố Đắk Lắk.", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0908116466", "Công ty cổ phần Du lịch Đắk Lắk", "Hoạt động" },
                    { "DT0002", 4.2f, "32 Nơ Trang Long, Tp. Buôn Ma Thuột, Đắk Lắk", "info@dakviettravel.com", "DakViet Travel, một địa chỉ du lịch đáng tin cậy, có trụ sở tại trung tâm của Việt Nam Tây Nguyên.", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0905057890", "Công ty TNHH Du lịch DakViet", "Hoạt động" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANH_DOI_TAC_IdDoiTac",
                table: "ANH_DOI_TAC",
                column: "IdDoiTac");

            migrationBuilder.CreateIndex(
                name: "IX_ANH_TOUR_IdTour",
                table: "ANH_TOUR",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_IdKhachHang",
                table: "DANH_GIA",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DANH_GIA_IdTour",
                table: "DANH_GIA",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_DAT_TOUR_IdKhachHang",
                table: "DAT_TOUR",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DAT_TOUR_IdNhanVien",
                table: "DAT_TOUR",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_DAT_TOUR_IdTour",
                table: "DAT_TOUR",
                column: "IdTour");

            migrationBuilder.CreateIndex(
                name: "IX_DICH_VU_CHI_TIET_IdDatTour",
                table: "DICH_VU_CHI_TIET",
                column: "IdDatTour");

            migrationBuilder.CreateIndex(
                name: "IX_DICH_VU_CHI_TIET_IdDichVu",
                table: "DICH_VU_CHI_TIET",
                column: "IdDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_DICH_VU_CHI_TIET_IdKhachHang",
                table: "DICH_VU_CHI_TIET",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DICH_VU_CHI_TIET_IdNhanVien",
                table: "DICH_VU_CHI_TIET",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_THANH_TOAN_IdDatTour",
                table: "THANH_TOAN",
                column: "IdDatTour");

            migrationBuilder.CreateIndex(
                name: "IX_THANH_TOAN_IdDichVuChiTiet",
                table: "THANH_TOAN",
                column: "IdDichVuChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_THANH_TOAN_IdKhachHang",
                table: "THANH_TOAN",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_THANH_TOAN_IdNhanVien",
                table: "THANH_TOAN",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_TOUR_DU_LICH_IdDoiTac",
                table: "TOUR_DU_LICH",
                column: "IdDoiTac");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANH_DOI_TAC");

            migrationBuilder.DropTable(
                name: "ANH_TOUR");

            migrationBuilder.DropTable(
                name: "DANH_GIA");

            migrationBuilder.DropTable(
                name: "THANH_TOAN");

            migrationBuilder.DropTable(
                name: "DICH_VU_CHI_TIET");

            migrationBuilder.DropTable(
                name: "DAT_TOUR");

            migrationBuilder.DropTable(
                name: "DICH_VU");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "NHAN_VIEN");

            migrationBuilder.DropTable(
                name: "TOUR_DU_LICH");

            migrationBuilder.DropTable(
                name: "DOI_TAC");
        }
    }
}
