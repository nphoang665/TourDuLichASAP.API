using Azure.Core;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;
using System.Net;
using System.Text;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;
using Twilio;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;

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
        private readonly JwtBearerOptions _jwtBearerOptions;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenReponsitory, IKhachHangRepositories khachHangRepositories, INhanVienRepositories nhanVienRepositories, IOptions<JwtBearerOptions> options)
        {
            this.userManager = userManager;
            this.tokenReponsitory = tokenReponsitory;
            _khachHangRepositories = khachHangRepositories;
            _nhanVienRepositories = nhanVienRepositories;
            _jwtBearerOptions = options.Value;
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
                            NgayDangKy = khachHang.NgayDangKy
                        });
                    }
                    //so sánh email kiểm tra xem tk này có trong khách hàng không
                    var existKhachHang = responseKhachHang.FirstOrDefault(s => s.Email == request.Email);
                    if (existKhachHang == null)
                    {
                        //tìm nhân viên
                        var nhanViens = await _nhanVienRepositories.GetAllAsync();
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
                            });
                        }

                        var existNhanVien = responseNhanVien.FirstOrDefault(s => s.Email == request.Email);
                        var response = new LoginResponseDto
                        {
                            NhanVien = existNhanVien,
                            Email = request.Email, // email đã check đúng với mật khẩu đã đúng
                            Roles = roles.ToList(),
                            Token = jwtToken
                        };
                        return Ok(response);
                    }
                    else
                    {
                        var response = new LoginResponseDto
                        {
                            KhachHang = existKhachHang,
                            Email = request.Email, // email đã check đúng với mật khẩu đã đúng
                            Roles = roles.ToList(),
                            Token = jwtToken
                        };
                        return Ok(response);
                    }


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
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idKhachHang = "KH" + randomValue.ToString("D4");
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
                    var khachHang = new KhachHang
                    {
                        IdKhachHang = idKhachHang,
                        TenKhachHang = "",
                        SoDienThoai = "",
                        DiaChi = "",
                        CCCD = "",
                        NgaySinh = DateTime.Now,
                        GioiTinh = "",
                        Email = request.Email,
                        TinhTrang = "Đang hoạt động",
                        NgayDangKy = DateTime.Now.Date,
                    };

                    await _khachHangRepositories.CreateAsync(khachHang);
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

        [HttpPost]
        [Route("registerNV")]
        public async Task<IActionResult> RegisterNV([FromBody] RegisterRequestDto request)
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
                identityResult = await userManager.AddToRoleAsync(user, "Nhân viên");
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


        //[HttpPost]
        //[Route("google-login")]
        //public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDto requestDto)
        //{
        //    var idToken = requestDto.IdToken;
        //    var setting = new GoogleJsonWebSignature.ValidationSettings
        //    {
        //        Audience = new string[] { "101863175272-n460ifjdvtb6gevl0sa64md26bt0r22v.apps.googleusercontent.com" }
        //    };
        //    var result = await GoogleJsonWebSignature.ValidateAsync(idToken, setting);
        //    if(result is null)
        //    {
        //        return BadRequest();
        //    }


        //}
        [HttpPost]
        [Route("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDto requestDto)
        {
             Random random = new Random();
            int randomValue = random.Next(1000);
            string idKhachHang = "KH" + randomValue.ToString("D4");


            // Xác thực token từ Google


            var idToken = requestDto.IdToken;
            var setting = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new string[] { "101863175272-n460ifjdvtb6gevl0sa64md26bt0r22v.apps.googleusercontent.com" },
            };

            // Xác thực token từ Google
            var result = await GoogleJsonWebSignature.ValidateAsync(idToken, setting);
            if (result is null)
            {
                return BadRequest();
            }

            // Lấy email từ token đã xác thực
            var userEmail = result.Email;
            requestDto.Email = result.Email;
            // Lấy thông tin từ token đã xác thực
            var userName = result.Name; // Lấy tên từ token

            // Kiểm tra xem email này đã tồn tại trong CSDL của bạn hay chưa
            var identityUser = await userManager.FindByEmailAsync(userEmail);

            if (identityUser != null)
            {
                // Nếu người dùng tồn tại, đồng bộ thông tin nếu cần (cập nhật bất kỳ thông tin nào)
                // Ví dụ: identityUser.Name = result.Name;
                // Cập nhật người dùng trong CSDL
                await userManager.UpdateAsync(identityUser);
            }
            else
            {
                // Nếu người dùng không tồn tại, tạo một người dùng mới
                var newUser = new IdentityUser
                {
                    UserName = userEmail,
                    Email = userEmail,
                };

                // Tạo người dùng
                var identityResult = await userManager.CreateAsync(newUser);
                if (identityResult.Succeeded)
                {



                    // Thêm vai trò mặc định cho người dùng (ví dụ: "Khách hàng")
                    identityResult = await userManager.AddToRoleAsync(newUser, "Khách hàng");
                    var khachHang = new KhachHang
                    {
                        IdKhachHang = idKhachHang,
                        TenKhachHang = userName,
                        SoDienThoai = "",
                        DiaChi = "",
                        CCCD = "",
                        NgaySinh = DateTime.Now,
                        GioiTinh = "",
                        Email = userEmail,
                        TinhTrang = "Đang hoạt động",
                        NgayDangKy = DateTime.Now.Date,
                    };

                    await _khachHangRepositories.CreateAsync(khachHang);
                    if (!identityResult.Succeeded)
                    {
                        // Xử lý lỗi
                        return BadRequest("Không thể gán vai trò cho người dùng.");
                    }
                }
                else
                {
                    // Xử lý lỗi
                    return BadRequest("Không thể tạo người dùng mới.");
                }
            }
            //thực hiện tìm kiếm lại người dùng trong bảng aspnetuser để get role
            var TimKiemLaiIdentityUser = await userManager.FindByEmailAsync(userEmail);
            // Tạo JWT token cho người dùng (tương tự như mã bạn đã có)
            var roles = await userManager.GetRolesAsync(TimKiemLaiIdentityUser);
            var jwtToken = tokenReponsitory.CreateJwtToken(TimKiemLaiIdentityUser, roles.ToList());

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
                    NgayDangKy = khachHang.NgayDangKy
                });
            }
            //so sánh email kiểm tra xem tk này có trong khách hàng không
            var existKhachHang = responseKhachHang.FirstOrDefault(s => s.Email == requestDto.Email);
            if (existKhachHang == null)
            {
                //tìm nhân viên
                var nhanViens = await _nhanVienRepositories.GetAllAsync();
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
                    });
                }

                var existNhanVien = responseNhanVien.FirstOrDefault(s => s.Email.ToLower() == requestDto.Email.ToLower());
                var response = new LoginResponseDto
                {
                    NhanVien = existNhanVien,
                    Email = requestDto.Email, // email đã check đúng với mật khẩu đã đúng
                    Roles = roles.ToList(),
                    Token = jwtToken
                };
                return Ok(response);
            }
            else
            {
                var response = new LoginResponseDto
                {
                    KhachHang = existKhachHang,
                    Email = requestDto.Email, // email đã check đúng với mật khẩu đã đúng
                    Roles = roles.ToList(),
                    Token = jwtToken
                };
                return Ok(response);
            }
        }
        [HttpPost]
        [Route("QuenMatKhau")]
        public async Task<IActionResult> QuenMatKhau()
        {  
            string accountSid = "ACf18c14d399f5f2e346ead9a895185608";
            string authToken = "8dd38e32df4d3516462e4c2d032f4c62";
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber("+84 869 536 182");  
            var from = new PhoneNumber("+14693012499");
            Random random = new Random();
            int otp = random.Next(100000, 999999);  
            var message = MessageResource.Create(
                to: to,
                from: from,
                body: $"Mã OTP đặt tour của bạn là: {otp}");
            return Ok();
        }
        [HttpPost]
        [Route("GuiEmailChoKhachHang")]
        public async Task<IActionResult> GuiMail()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string MaXacNhan;
            Random rnd = new Random();
            MaXacNhan = rnd.Next().ToString();

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("khachsanasap@gmail.com", "ulwg gvjl vqmb iwya");

            MailMessage mail = new MailMessage();
            mail.To.Add("nhutbmt82@gmail.com");
            mail.From = new MailAddress("khachsanasap@gmail.com");
            mail.Subject = "Thông Báo Quan Trọng Từ Khách Sạn ASAP";

            string logoUrl = "https://i.imgur.com/2VUOkoU.png";

            // Đọc nội dung từ file HTML
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Template/index.html");

            string htmlFilePath = folderPath; // Đường dẫn tới file HTML của bạn
            string htmlContent = System.IO.File.ReadAllText(htmlFilePath);

            byte[] pdf; // Biến này sẽ chứa dữ liệu PDF
            using (var stream = new MemoryStream())
            {
                var document = new Document();
                var writer = PdfWriter.GetInstance(document, stream);
                document.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, new StringReader(htmlContent));
                document.Close();
                pdf = stream.ToArray();
            }

            // Tạo tệp đính kèm từ file PDF
            Attachment attachment = new Attachment(new MemoryStream(pdf), "bill.pdf");
            mail.Attachments.Add(attachment);

            await smtp.SendMailAsync(mail);
            return Ok();
        }

    }
}
