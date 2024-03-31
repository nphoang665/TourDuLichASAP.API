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
                UserName = "Admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "admin123");
            builder.Entity<IdentityUser>().HasData(admin);

            // Trao vai trò cho quản trị viên
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = nhanVienRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = khachHangRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }

    }
}
