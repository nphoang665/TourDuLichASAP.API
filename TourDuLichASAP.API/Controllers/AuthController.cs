using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System.Net;
using System.Net.Mail;
using System.Text;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static iTextSharp.text.pdf.AcroFields;


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
        private readonly IThanhToanRepositories _thanhToanRepositories;
        private readonly IDatTourRepositories _datTourRepositories;
        private readonly IDichVuChiTietRepositories _dichVuChiTietRepositories;
        private readonly ITourDuLichRepositories _tourDuLichRepositories;






        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenReponsitory, IKhachHangRepositories khachHangRepositories, INhanVienRepositories nhanVienRepositories, IOptions<JwtBearerOptions> options, IThanhToanRepositories thanhToanRepositories, IDatTourRepositories datTourRepositories,IDichVuChiTietRepositories dichVuChiTietRepositories, ITourDuLichRepositories tourDuLichRepositories)
        {
            this.userManager = userManager;
            this.tokenReponsitory = tokenReponsitory;
            _khachHangRepositories = khachHangRepositories;
            _nhanVienRepositories = nhanVienRepositories;
            _jwtBearerOptions = options.Value;
            _thanhToanRepositories = thanhToanRepositories;
            _datTourRepositories = datTourRepositories;
            _dichVuChiTietRepositories = dichVuChiTietRepositories;
            _tourDuLichRepositories = tourDuLichRepositories;
            
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
                        TenKhachHang = request.Username,
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
            htmlContent = await XuLyHoaDonThanhToan(htmlContent);

            byte[] pdf;

            // Khởi tạo trình duyệt
            await new BrowserFetcher().DownloadAsync();
            using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true }))
            {
                using (var page = await browser.NewPageAsync())
                {
                    // Đặt nội dung HTML cho trang
                    await page.SetContentAsync(htmlContent);

                    // Chuyển đổi trang thành PDF
                    pdf = await page.PdfDataAsync(new PdfOptions { Format = PaperFormat.A4 });
                }
            }

            // Tạo tệp đính kèm từ file PDF
            Attachment attachment = new Attachment(new MemoryStream(pdf), "bill.pdf");
            mail.Attachments.Add(attachment);

            await smtp.SendMailAsync(mail);
            return Ok();
        }
        async Task<string> XuLyHoaDonThanhToan(string htmlContent)
        {
            //lấy thanh toán
            var thanhToan = await _thanhToanRepositories.GetByIdAsync("TT0446");
            if (thanhToan == null)
            {
                return "";
            }

            var responseThanhToan = new ThanhToanDto
            {
                IdThanhToan = thanhToan.IdThanhToan,
                IdDatTour = thanhToan.IdDatTour,
                IdKhachHang = thanhToan.IdKhachHang,
                IdNhanVien = thanhToan.IdNhanVien,
                TongTienTour = thanhToan.TongTienTour,
                TongTienDichVu = thanhToan.TongTienDichVu,
                TongTien = thanhToan.TongTien,
                TinhTrang = thanhToan.TinhTrang,
                NgayThanhToan = thanhToan.NgayThanhToan,
                PhuongThucThanhToan = thanhToan.PhuongThucThanhToan,
            };
            htmlContent = htmlContent.Replace("{{MaHoaDon}}", responseThanhToan.IdThanhToan);
            htmlContent = htmlContent.Replace("{{NgayTaoHoaDon}}", responseThanhToan.NgayThanhToan.ToString());

            //GET ĐẶT TOUR 
            var datTour = await _datTourRepositories.GetByIdAsync(responseThanhToan.IdDatTour);
            if (datTour is null)
            {
                return "";
            }

            var responseDatTour = new DatTourDto
            {
                IdDatTour = datTour.IdDatTour,
                IdKhachHang = datTour.IdKhachHang,
                IdTour = datTour.IdTour,
                SoLuongNguoiLon = datTour.SoLuongNguoiLon,
                SoLuongTreEm = datTour.SoLuongTreEm,
                GhiChu = datTour.GhiChu,
                IdNhanVien = datTour.IdNhanVien,
                ThoiGianDatTour = datTour.ThoiGianDatTour,
                TinhTrang = datTour.TinhTrang,
                KhachHang = datTour.KhachHang,
                NhanVien = datTour.NhanVien != null ? datTour.NhanVien.IdNhanVien : null,
                TourDuLich = datTour.TourDuLich != null ? datTour.TourDuLich.IdTour : null,
            };
            var tourDuLich = await _tourDuLichRepositories.GetByIdAsync(responseDatTour.IdTour);
            if (tourDuLich is null)
            {
                return "";
            }

            var responseTour = new TourDuLichDto
            {
                IdTour = tourDuLich.IdTour,
                TenTour = tourDuLich.TenTour,
                LoaiTour = tourDuLich.LoaiTour,
                PhuongTienDiChuyen = tourDuLich.PhuongTienDiChuyen,
                MoTa = tourDuLich.MoTa,
                SoLuongNguoiLon = tourDuLich.SoLuongNguoiLon,
                SoLuongTreEm = tourDuLich.SoLuongTreEm,
                ThoiGianBatDau = tourDuLich.ThoiGianBatDau,
                ThoiGianKetThuc = tourDuLich.ThoiGianKetThuc,
                NoiKhoiHanh = tourDuLich.NoiKhoiHanh,
                SoChoConNhan = tourDuLich.SoChoConNhan,
                IdDoiTac = tourDuLich.IdDoiTac,
                GiaTreEm = tourDuLich.GiaTreEm,
                GiaNguoiLon = tourDuLich.GiaNguoiLon,
                NgayThem = tourDuLich.NgayThem,
                DichVuDiKem = tourDuLich.DichVuDiKem,
                TinhTrang = tourDuLich.TinhTrang,
                TenDoiTac = tourDuLich.DoiTac.TenDoiTac,
                EmailDoiTac = tourDuLich.DoiTac.Email,
                SoDienThoaiDoiTac = tourDuLich.DoiTac.SoDienThoai,
            };
            if (responseTour != null)
            {
               
                htmlContent = htmlContent.Replace("{{TenTour}}", responseTour.TenTour);
                htmlContent = htmlContent.Replace("{{SoLuongNguoiLon_DatTour}}", responseDatTour.SoLuongNguoiLon.ToString());
                htmlContent = htmlContent.Replace("{{SoLuongTreEm_DatTour}}", responseDatTour.SoLuongTreEm.ToString());
                htmlContent = htmlContent.Replace("{{ThoiGianDatTour}}", responseDatTour.ThoiGianDatTour.ToString());
            }

            //gán thông tin nhân viên và khách hàng
            htmlContent = htmlContent.Replace("{{TenKhachHangThanhToan}}", responseDatTour.KhachHang.TenKhachHang);
            htmlContent = htmlContent.Replace("{{SoDienThoaiKhachHangThanhToan}}", responseDatTour.KhachHang.SoDienThoai);
            htmlContent = htmlContent.Replace("{{EmailKhachHangThanhToan}}", responseDatTour.KhachHang.Email);
            //khách hàng
            if(responseDatTour.IdNhanVien != null)
            {
                var nhanVien = await _nhanVienRepositories.GetByIdAsync(responseDatTour.IdNhanVien);
                
                var responseNhanVien = new NhanVienDto
                {
                    IdNhanVien = nhanVien.IdNhanVien,
                    TenNhanVien = nhanVien.TenNhanVien,
                    SoDienThoai = nhanVien.SoDienThoai,
                    DiaChi = nhanVien.DiaChi,
                    CCCD = nhanVien.CCCD,
                    NgaySinh = nhanVien.NgaySinh,
                    Email = nhanVien.Email,
                    GioiTinh = nhanVien.GioiTinh,
                    NgayDangKy = nhanVien.NgayDangKy,
                    ChucVu = nhanVien.ChucVu,
                    NgayVaoLam = nhanVien.NgayVaoLam,
                    TinhTrang = nhanVien.TinhTrang,
                };
                htmlContent = htmlContent.Replace("{{TenNhanVienThanhToan}}", responseNhanVien.TenNhanVien);
                htmlContent = htmlContent.Replace("{{SoDienThoaiNhanVienThanhToan}}", responseNhanVien.SoDienThoai);
                htmlContent = htmlContent.Replace("{{EmailNhanVienThanhToan}}", responseNhanVien.Email);

            }

            //lấy dịch vụ
            var dichVuChiTiets = await _dichVuChiTietRepositories.GetAllAsync();

            var responseDichVu = new List<DichVuChiTietDto>();
            foreach (var dichVuChiTiet in dichVuChiTiets)
            {
                responseDichVu.Add(new DichVuChiTietDto
                {
                    IdDichVuChiTiet = dichVuChiTiet.IdDichVuChiTiet,
                    IdDichVu = dichVuChiTiet.IdDichVu,
                    IdKhachHang = dichVuChiTiet.IdKhachHang,
                    IdDatTour = dichVuChiTiet.IdDatTour,
                    IdNhanVien = dichVuChiTiet.IdNhanVien,
                    ThoiGianDichVu = dichVuChiTiet.ThoiGianDichVu,
                    SoLuong = dichVuChiTiet.SoLuong,
                    KhachHang = dichVuChiTiet.KhachHang,
                    NhanVien = dichVuChiTiet.NhanVien,
                    DichVu = dichVuChiTiet.DichVu,
                    DatTour = dichVuChiTiet.DatTour

                });
            }
            if(responseDichVu.Count > 0)
            {
                var dichVuDuocDat = responseDichVu.Where(s => s.IdDatTour == responseThanhToan.IdDatTour).ToList();
                int startTrIndex = htmlContent.IndexOf("<tr class=\"item tr_item_DichVu\">");
                int endTrIndex = htmlContent.IndexOf("</tr>", startTrIndex) + 5; // +5 để bao gồm cả thẻ </tr>
                string trContent = htmlContent.Substring(startTrIndex, endTrIndex - startTrIndex);
                // Biến để lưu nội dung HTML cuối cùng
                StringBuilder finalHtmlContent = new StringBuilder();

                // Lặp qua từng mục trong danh sách
                foreach (var item in dichVuDuocDat)
                {
                    // Sao chép nội dung HTML gốc
                    string itemHtmlContent = string.Copy(trContent);

                    // Thay thế các placeholder trong HTML với dữ liệu thực tế
                    itemHtmlContent = itemHtmlContent.Replace("{{TenDichVu}}", item.DichVu.TenDichVu);
                    itemHtmlContent = itemHtmlContent.Replace("{{SoLuongDichVu}}", item.SoLuong.ToString());
                    itemHtmlContent = itemHtmlContent.Replace("{{DonGiaDichVu}}", item.DichVu.GiaTien.ToString());
                    itemHtmlContent = itemHtmlContent.Replace("{{ThoiGianDichVu}}", item.ThoiGianDichVu.ToString());



                    finalHtmlContent.Append(itemHtmlContent);
                }
               
                htmlContent = htmlContent.Replace("{{TongTienTour}}", responseThanhToan.TongTienTour.ToString());
                htmlContent = htmlContent.Replace("{{TongTienDichVu}}", responseThanhToan.TongTienDichVu.ToString());
                htmlContent = htmlContent.Replace("{{TongCong}}", responseThanhToan.TongTien.ToString());

                htmlContent = htmlContent.Replace(trContent, finalHtmlContent.ToString());
            }





            return htmlContent;
        }



    }
}
