using TourDuLichASAP.API.Models.Domain;

namespace TourDuLichASAP.API.Repositories.Interface
{
    public interface IDanhGiaRepositories
    {
        Task<IEnumerable<DanhGia>> LayTatCaDanhGia();
    }
}
