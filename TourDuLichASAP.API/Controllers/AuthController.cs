using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenReponsitory;
        private readonly IKhachHangRepositories _khachHangRepositories;
        private readonly INhanVienRepositories _nhanVienRepositories;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenReponsitory, IKhachHangRepositories khachHangRepositories, INhanVienRepositories nhanVienRepositories)
        {
            this.userManager = userManager;
            this.tokenReponsitory = tokenReponsitory;
            _khachHangRepositories = khachHangRepositories;
            _nhanVienRepositories = nhanVienRepositories;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var identityUser = await userManager.FindByEmailAsync(request.Email);

            if (identityUser is not null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, request.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);

                    var jwtToken = tokenReponsitory.CreateJwtToken(identityUser, roles.ToList());

                    var response = new LoginResponseDto
                    {
                        Email = request.Email, // email đã check đúng với mật khẩu đã đúng
                        Roles = roles.ToList(),
                        Token = jwtToken
                    };
                   // code lấy full data khách hàng
                   var khachHangs = await _khachHangRepositories.GetAllAsync();
                    var responseKhachHang = new List<KhachHangDto>();
                    foreach (var khachHang in khachHangs)
                    {
                        responseKhachHang.Add(new KhachHangDto
                        {
                            IdKhachHang = khachHang.IdKhachHang,
                            TenKhachHang = khachHang.TenKhachHang,
                            SoDienThoai = khachHang.SoDienThoai,
                            DiaChi = khachHang.DiaChi,
                            CCCD = khachHang.CCCD,
                            NgaySinh = khachHang.NgaySinh,
                            GioiTinh = khachHang.GioiTinh,
                            Email = khachHang.Email,
                            TinhTrang = khachHang.TinhTrang,
                            MatKhau = khachHang.MatKhau,
                            NgayDangKy = khachHang.NgayDangKy
                        });
                    }
                    //so sánh email kiểm tra xem tk này có trong khách hàng không
                    var existKhachHang = responseKhachHang.FirstOrDefault(s => s.Email == response.Email);
                    if(existKhachHang == null)
                    {
                        //tìm nhân viên
                        var nhanViens= await _nhanVienRepositories.GetAllAsync();
                        var responseNhanVien = new List<NhanVienDto>();
                        foreach (var nhanvien in nhanViens)
                        {
                            responseNhanVien.Add(new NhanVienDto
                            {
                                IdNhanVien = nhanvien.IdNhanVien,
                                TenNhanVien = nhanvien.TenNhanVien,
                                SoDienThoai = nhanvien.SoDienThoai,
                                DiaChi = nhanvien.DiaChi,
                                CCCD = nhanvien.CCCD,
                                NgaySinh = nhanvien.NgaySinh,
                                Email = nhanvien.Email,
                                GioiTinh = nhanvien.GioiTinh,
                                NgayDangKy = nhanvien.NgayDangKy,
                                ChucVu = nhanvien.ChucVu,
                                NgayVaoLam = nhanvien.NgayVaoLam,
                                AnhNhanVien = nhanvien.AnhNhanVien,
                                TinhTrang = nhanvien.TinhTrang,
                                MatKhau = nhanvien.MatKhau
                            });
                        }

                        var existNhanVien = responseNhanVien.FirstOrDefault(s => s.Email == response.Email);

                        return Ok(existNhanVien);
                    }

                    return Ok(existKhachHang);
                }
                else
                {
                    // Mật khẩu không đúng
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
            }
            else
            {
                // Tài khoản không tồn tại
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }

            return ValidationProblem(ModelState);
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            // Create IdentityUser object
            var user = new IdentityUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),
            };

            //Create User 
            var identityResult = await userManager.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {
                // Add role to User (Reader)
                identityResult = await userManager.AddToRoleAsync(user, "Khách hàng");
                if (identityResult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                if (identityResult.Errors.Any())
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return ValidationProblem(ModelState);
        }
    }
}
