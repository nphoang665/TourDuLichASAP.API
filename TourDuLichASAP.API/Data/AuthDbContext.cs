using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TourDuLichASAP.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "4304b846-6ee9-4800-a670-ccf11eabae35";
            var nhanVienRoleId = "8db11b28-ce22-475f-8b1e-d23d2e100fcf";
            var khachHangRoleId = "294bb644-8b4e-4d5b-8bab-e5ed8b2d864e";

            //Tao
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                },
                 new IdentityRole()
                {
                    Id = nhanVienRoleId,
                    Name = "Nhân viên",
                    NormalizedName = "Nhân viên".ToUpper(),
                    ConcurrencyStamp = nhanVienRoleId
                }, new IdentityRole()
                {
                    Id = khachHangRoleId,
                    Name = "Khách hàng",
                    NormalizedName = "Khách hàng".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //Tạo admin
            var adminUserId = "b83cf6dd-435c-48cd-8c16-06338e726032";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper()
            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "admin123");

            //Tạo nhân viên
            var nhanvienId = "cf1cd73a-9d5e-4a19-8e77-28c13c57f39b";
            var nhanVien = new IdentityUser()
            {
                Id = nhanvienId,
                UserName = "Nhân viên",
                Email = "nhanvien@gmail.com",
                NormalizedEmail = "nhanvien@gmail.com".ToUpper(),
                NormalizedUserName = "nhanvien@gmail.com".ToUpper()
            };
            nhanVien.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(nhanVien, "nhanvien123");

            //Tạo khách hàng
            var khachHangId = "90b2ba0b-c552-44f6-bf4d-cc46fa5731b5";
            var khachHang = new IdentityUser()
            {
                Id = khachHangId,
                UserName = "Khách hàng",
                Email = "khachhang@gmail.com",
                NormalizedEmail = "khachhang@gmail.com".ToUpper(),
                NormalizedUserName = "khachhang@gmail.com".ToUpper()
            };
            khachHang.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(khachHang, "khachhang123");

            builder.Entity<IdentityUser>().HasData(admin);
            builder.Entity<IdentityUser>().HasData(nhanVien);
            builder.Entity<IdentityUser>().HasData(khachHang);

            // Trao vai trò cho quản trị viên
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

            var nhanvienRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = nhanvienId,
                    RoleId = nhanVienRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(nhanvienRoles);

            var khachHangRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = khachHangId,
                    RoleId = khachHangRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(khachHangRoles);
        }

    }
}
