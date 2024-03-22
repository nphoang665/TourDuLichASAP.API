using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDuLichASAP.API.Models.Domain;
using TourDuLichASAP.API.Models.DTO;
using TourDuLichASAP.API.Repositories.Interface;

namespace TourDuLichASAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class TourDuLichController : ControllerBase
    {
        private readonly ITourDuLichRepositories _tourDuLichRepositories;
        private readonly IAnhTourRepositories _anhTourRepositories;

        public TourDuLichController(ITourDuLichRepositories tourDuLichRepositories, IAnhTourRepositories anhTourRepositories)
        {
            _tourDuLichRepositories = tourDuLichRepositories;
            _anhTourRepositories  = anhTourRepositories;
        }

        [HttpPost]
        public async Task <IActionResult> CreateTourDuLich([FromBody] CreateTourDuLichRequestDto requestDto)
        {
           
            Random random = new Random();
            int randomValue = random.Next(1000);
            string idTour = "TDL" + randomValue.ToString("D3");
            
            //convert
            var tourDuLich = new TourDuLich
            {
                IdTour = idTour,
                TenTour = requestDto.TenTour,
                LoaiTour = requestDto.LoaiTour,
                PhuongTienDiChuyen = requestDto.PhuongTienDiChuyen,
                MoTa = requestDto.MoTa,
                SoLuongNguoiLon = requestDto.SoLuongNguoiLon,
                SoLuongTreEm = requestDto.SoLuongTreEm,
                ThoiGianBatDau = requestDto.ThoiGianBatDau,
                ThoiGianKetThuc = requestDto.ThoiGianKetThuc,
                NoiKhoiHanh = requestDto.NoiKhoiHanh,
                SoChoConNhan = requestDto.SoChoConNhan,
                IdDoiTac = requestDto.IdDoiTac,
                GiaTreEm = requestDto.GiaTreEm,
                GiaNguoiLon = requestDto.GiaNguoiLon,
                NgayThem = DateTime.Now,
                DichVuDiKem = requestDto.DichVuDiKem,
                TinhTrang = "Đang hoạt động",
            };


            var doiTac = await _tourDuLichRepositories.GetDoiTacAsync(requestDto.IdDoiTac);
            tourDuLich.DoiTac = doiTac;
            tourDuLich = await _tourDuLichRepositories.CreateAsync(tourDuLich);

            var response = new TourDuLichDto
            {
                IdTour = requestDto.IdTour,
                TenTour = requestDto.TenTour,
                LoaiTour = requestDto.LoaiTour,
                PhuongTienDiChuyen = requestDto.PhuongTienDiChuyen,
                MoTa = requestDto.MoTa,
                SoLuongNguoiLon = requestDto.SoLuongNguoiLon,
                SoLuongTreEm = requestDto.SoLuongTreEm,
                ThoiGianBatDau = requestDto.ThoiGianBatDau,
                ThoiGianKetThuc = requestDto.ThoiGianKetThuc,
                NoiKhoiHanh = requestDto.NoiKhoiHanh,
                SoChoConNhan = requestDto.SoChoConNhan,
                IdDoiTac = requestDto.IdDoiTac,
                GiaTreEm = requestDto.GiaTreEm,
                GiaNguoiLon = requestDto.GiaNguoiLon,
                NgayThem = requestDto.NgayThem,
                DichVuDiKem = requestDto.DichVuDiKem,
                TinhTrang = requestDto.TinhTrang,
                TenDoiTac = doiTac.TenDoiTac,
                EmailDoiTac = doiTac.Email,
                SoDienThoaiDoiTac = doiTac.SoDienThoai
            };
            if (requestDto.ImgSelected != null)
            {
                // Tạo thư mục 'uploads' nếu nó chưa tồn tại
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                for (int i = 0; i < requestDto.ImgSelected.Length; i++)
                {
                    // Tách chuỗi Base64 và loại media
                    var parts = requestDto.ImgSelected[i].Split(',');
                    string mediaType = parts[0]; // Ví dụ: "data:image/jpeg;base64"
                    string base64 = parts[1];

                    // Chuyển đổi chuỗi Base64 thành mảng byte
                    byte[] imageBytes = Convert.FromBase64String(base64);

                    // Xác định định dạng file từ loại media
                    var format = mediaType.Split(';')[0].Split('/')[1]; // Ví dụ: "jpeg"

                    // Tạo tên file duy nhất cho mỗi hình ảnh
                    string fileName = $"image_{i}_{DateTime.Now.Ticks}.{format}";

                    // Tạo đường dẫn đầy đủ cho file
                    string filePath = Path.Combine(folderPath, fileName);

                    // Ghi mảng byte vào file
                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    var anhTour = new AnhTour
                    {
                        IdTour = idTour,
                        ImgTour = fileName,
                        NgayThem = DateTime.Now
                    };
                    await _anhTourRepositories.UploadImg(anhTour);
                }

            }

            return Ok(response);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllTourDuLich()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            var tourDuLichs = await _tourDuLichRepositories.GetAllAsync();
         
            
            //convert
            var response = new List<TourDuLichDto>();
            foreach (var tourDuLich in tourDuLichs)
            {
                //lấy ảnh tour theo id
                var AnhTour = await _anhTourRepositories.GetImgTourById(tourDuLich.IdTour);
                response.Add(new TourDuLichDto
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
                    AnhTour = AnhTour
                });
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTourDuLichById(string id)
        {
            var tourDuLich = await _tourDuLichRepositories.GetByIdAsync(id);
            var anhtour = await _tourDuLichRepositories.GetAnhTourByIdAsync(id);
            if (tourDuLich is null)
            {
                return NotFound();
            }

            var response = new TourDuLichDto
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
                AnhTour = anhtour
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTourDuLichById(string id, UpdateTourDuLichRequestDto dto)
        {
            var tourDuLich = new TourDuLich
            { 
                IdTour = id,
                TenTour = dto.TenTour,
                LoaiTour = dto.LoaiTour,
                PhuongTienDiChuyen = dto.PhuongTienDiChuyen,
                MoTa = dto.MoTa,
                SoLuongNguoiLon = dto.SoLuongNguoiLon,
                SoLuongTreEm = dto.SoLuongTreEm,
                ThoiGianBatDau = dto.ThoiGianBatDau,
                ThoiGianKetThuc = dto.ThoiGianKetThuc,
                NoiKhoiHanh = dto.NoiKhoiHanh,
                SoChoConNhan = dto.SoChoConNhan,
                IdDoiTac = dto.IdDoiTac,
                GiaTreEm = dto.GiaTreEm,
                GiaNguoiLon = dto.GiaNguoiLon,
                NgayThem = dto.NgayThem,
                DichVuDiKem = dto.DichVuDiKem,
                TinhTrang = dto.TinhTrang,
            };

            var doiTac = await _tourDuLichRepositories.GetDoiTacAsync(dto.IdDoiTac);
            tourDuLich.DoiTac = doiTac;
            tourDuLich = await _tourDuLichRepositories.UpdateAsync(tourDuLich);

            if (tourDuLich == null)
            {
                return NotFound();
            }
            //xóa ảnh đã có trong db
            if (dto.AnhTourDb != null)
            {
                foreach (var item in dto.AnhTourDb)
                {
                     _anhTourRepositories.RemoveImgByName(item);
                }
            }

            //thêm ảnh mới vào db
            if (dto.AnhTourBrowse != null)
            {
                // Tạo thư mục 'uploads' nếu nó chưa tồn tại
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                for (int i = 0; i < dto.AnhTourBrowse.Length; i++)
                {
                    // Tách chuỗi Base64 và loại media
                    var parts = dto.AnhTourBrowse[i].Split(',');
                    string mediaType = parts[0]; // Ví dụ: "data:image/jpeg;base64"
                    string base64 = parts[1];

                    // Chuyển đổi chuỗi Base64 thành mảng byte
                    byte[] imageBytes = Convert.FromBase64String(base64);

                    // Xác định định dạng file từ loại media
                    var format = mediaType.Split(';')[0].Split('/')[1]; // Ví dụ: "jpeg"

                    // Tạo tên file duy nhất cho mỗi hình ảnh
                    string fileName = $"image_{i}_{DateTime.Now.Ticks}.{format}";

                    // Tạo đường dẫn đầy đủ cho file
                    string filePath = Path.Combine(folderPath, fileName);

                    // Ghi mảng byte vào file
                    System.IO.File.WriteAllBytes(filePath, imageBytes);

                    var anhTour = new AnhTour
                    {
                        IdTour = tourDuLich.IdTour,
                        ImgTour = fileName,
                        NgayThem = DateTime.Now
                    };
                    await _anhTourRepositories.UploadImg(anhTour);
                }

            }
           
            var response = new TourDuLichDto
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
                SoDienThoaiDoiTac = tourDuLich.DoiTac.SoDienThoai
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTourDuLich(string id)
        {
            var deleteTourDuLich = await _tourDuLichRepositories.DeleteAsync(id);
            if(deleteTourDuLich == null)
            {
                return NotFound();
            }

            var response = new TourDuLich
            {
                IdTour = id,
                TenTour = deleteTourDuLich.TenTour,
                LoaiTour = deleteTourDuLich.LoaiTour,
                PhuongTienDiChuyen = deleteTourDuLich.PhuongTienDiChuyen,
                MoTa = deleteTourDuLich.MoTa,
                SoLuongNguoiLon = deleteTourDuLich.SoLuongNguoiLon,
                SoLuongTreEm = deleteTourDuLich.SoLuongTreEm,
                ThoiGianBatDau = deleteTourDuLich.ThoiGianBatDau,
                ThoiGianKetThuc = deleteTourDuLich.ThoiGianKetThuc,
                NoiKhoiHanh = deleteTourDuLich.NoiKhoiHanh,
                SoChoConNhan = deleteTourDuLich.SoChoConNhan,
                IdDoiTac = deleteTourDuLich.IdDoiTac,
                GiaTreEm = deleteTourDuLich.GiaTreEm,
                GiaNguoiLon = deleteTourDuLich.GiaNguoiLon,
                NgayThem = deleteTourDuLich.NgayThem,
                DichVuDiKem = deleteTourDuLich.DichVuDiKem,
                TinhTrang = deleteTourDuLich.TinhTrang,
            };
            return Ok(response);
        }
    }
}
