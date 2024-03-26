using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourDuLichASAP.API.Migrations
{
    /// <inheritdoc />
    public partial class suaLaiGio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "GioKetThuc",
                table: "DICH_VU",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "GioBatDau",
                table: "DICH_VU",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "DAT_TOUR",
                keyColumn: "IdDatTour",
                keyValue: "TLD002",
                column: "ThoiGianDatTour",
                value: new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0001",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0002",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0001",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5562), new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5579) });

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0002",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5585), new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL001",
                column: "NgayThem",
                value: new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 26, 15, 52, 44, 843, DateTimeKind.Local).AddTicks(5634));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "GioKetThuc",
                table: "DICH_VU",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GioBatDau",
                table: "DICH_VU",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.UpdateData(
                table: "DAT_TOUR",
                keyColumn: "IdDatTour",
                keyValue: "TLD002",
                column: "ThoiGianDatTour",
                value: new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0001",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0002",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0001",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4200), new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0002",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4215), new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL001",
                column: "NgayThem",
                value: new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4264));
        }
    }
}
