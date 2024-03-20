using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourDuLichASAP.API.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullSomeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdNhanVien",
                table: "DICH_VU_CHI_TIET",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.UpdateData(
                table: "DAT_TOUR",
                keyColumn: "IdDatTour",
                keyValue: "TLD002",
                column: "ThoiGianDatTour",
                value: new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0001",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1545));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0002",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0001",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1502), new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1514) });

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0002",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1519), new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL001",
                column: "NgayThem",
                value: new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1672));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdNhanVien",
                table: "DICH_VU_CHI_TIET",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DAT_TOUR",
                keyColumn: "IdDatTour",
                keyValue: "TLD002",
                column: "ThoiGianDatTour",
                value: new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0001",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "KHACH_HANG",
                keyColumn: "IdKhachHang",
                keyValue: "KH0002",
                column: "NgayDangKy",
                value: new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0001",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1594), new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1604) });

            migrationBuilder.UpdateData(
                table: "NHAN_VIEN",
                keyColumn: "IdNhanVien",
                keyValue: "NV0002",
                columns: new[] { "NgayDangKy", "NgayVaoLam" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1609), new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL001",
                column: "NgayThem",
                value: new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 20, 21, 53, 4, 210, DateTimeKind.Local).AddTicks(1669));
        }
    }
}
