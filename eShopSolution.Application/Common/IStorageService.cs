using System.IO;
using System.Threading.Tasks;

namespace eShopSolution.Application.Common
{
    public interface IStorageService
    {
        string GetProductImageFileUrl(string imageFileName);

        string GetCarouselImageFileUrl(string imageFileName);

        Task SaveProductImageAsync(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
    }
}