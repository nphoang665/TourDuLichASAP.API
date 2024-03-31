using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourDuLichASAP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAnhTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ANH_TOUR",
                keyColumn: "IdAnhTour",
                keyValue: 1,
                columns: new[] { "ImgTour", "NgayThem" },
                values: new object[] { "image_0_638475168948066701.jpeg", new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(5017) });

            migrationBuilder.UpdateData(
                table: "ANH_TOUR",
                keyColumn: "IdAnhTour",
                keyValue: 2,
                columns: new[] { "ImgTour", "NgayThem" },
                values: new object[] { "image_0_638475170750328322.gif", new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(5031) });

            migrationBuilder.UpdateData(
                table: "DAT_TOUR",
                keyColumn: "IdDatTour",
                keyValue: "TLD002",
                column: "ThoiGianDatTour",
                value: new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0001",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0002",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0001",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4758), new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0002",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4774), new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4775) });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL001",
                column: "NgayThem",
                value: new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 31, 21, 30, 35, 226, DateTimeKind.Local).AddTicks(4981));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ANH_TOUR",
                keyColumn: "IdAnhTour",
                keyValue: 1,
                columns: new[] { "ImgTour", "NgayThem" },
                values: new object[] { "image_1_638475131110106716", new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "ANH_TOUR",
                keyColumn: "IdAnhTour",
                keyValue: 2,
                columns: new[] { "ImgTour", "NgayThem" },
                values: new object[] { "image_0_638475157256078295", new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(600) });

            migrationBuilder.UpdateData(
                table: "DAT_TOUR",
                keyColumn: "IdDatTour",
                keyValue: "TLD002",
                column: "ThoiGianDatTour",
                value: new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0001",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0002",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0001",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(485), new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(495) });

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0002",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(499), new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL001",
                column: "NgayThem",
                value: new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 31, 21, 13, 52, 235, DateTimeKind.Local).AddTicks(562));
        }
    }
}
