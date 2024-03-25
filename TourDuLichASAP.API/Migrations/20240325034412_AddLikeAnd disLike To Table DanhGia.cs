using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourDuLichASAP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddLikeAnddisLikeToTableDanhGia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DANH_GIA_TOUR_DU_LICH_IdTour",
                table: "DANH_GIA");

            migrationBuilder.AlterColumn<string>(
                name: "IdTour",
                table: "DANH_GIA",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<int>(
                name: "DisLike",
                table: "DANH_GIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "DANH_GIA",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "NgayThem", "PhuongTienDiChuyen" },
                values: new object[] { new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4260), "Xe ô tô" });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 25, 10, 44, 10, 698, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.AddForeignKey(
                name: "FK_DANH_GIA_TOUR_DU_LICH_IdTour",
                table: "DANH_GIA",
                column: "IdTour",
                principalTable: "TOUR_DU_LICH",
                principalColumn: "IdTour");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DANH_GIA_TOUR_DU_LICH_IdTour",
                table: "DANH_GIA");

            migrationBuilder.DropColumn(
                name: "DisLike",
                table: "DANH_GIA");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "DANH_GIA");

            migrationBuilder.AlterColumn<string>(
                name: "IdTour",
                table: "DANH_GIA",
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
                columns: new[] { "NgayThem", "PhuongTienDiChuyen" },
                values: new object[] { new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1667), "Xe ô tô du lịch" });

            migrationBuilder.UpdateData(
                table: "TOUR_DU_LICH",
                keyColumn: "IdTour",
                keyValue: "TDL002",
                column: "NgayThem",
                value: new DateTime(2024, 3, 20, 21, 59, 25, 726, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.AddForeignKey(
                name: "FK_DANH_GIA_TOUR_DU_LICH_IdTour",
                table: "DANH_GIA",
                column: "IdTour",
                principalTable: "TOUR_DU_LICH",
                principalColumn: "IdTour",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
