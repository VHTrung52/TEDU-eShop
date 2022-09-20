using eShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace eShopSolution.Application.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly string _userContentFolderPath;

        public FileStorageService(
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _userContentFolderPath = Path.Combine(webHostEnvironment.WebRootPath, _configuration[SystemConstants.AppSettings.UserContentFolder]);
        }

        public string GetProductImageFileUrl(string fileName)
        {
            if(fileName == null)
                return string.Empty;

            var filePath = Path.Combine(_userContentFolderPath, _configuration[SystemConstants.AppSettings.ProductImage], fileName);
            if (!File.Exists(filePath))
                return string.Empty;

            return $"{_configuration[SystemConstants.AppSettings.BaseAddress]}/{_configuration[SystemConstants.AppSettings.UserContentFolder]}/{_configuration[SystemConstants.AppSettings.ProductImage]}/{fileName}";
        }

        public string GetCarouselImageFileUrl(string fileName)
        {
            if (fileName == null)
                return string.Empty;

            var filePath = Path.Combine(_userContentFolderPath, _configuration[SystemConstants.AppSettings.CarouselImage], fileName);
            if (!File.Exists(filePath))
                return string.Empty;

            return $"{_configuration[SystemConstants.AppSettings.BaseAddress]}/{_configuration[SystemConstants.AppSettings.UserContentFolder]}/{_configuration[SystemConstants.AppSettings.CarouselImage]}/{fileName}";
        }

        //public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        //{
        //    var filePath = Path.Combine(_userContentFolderPath, fileName);
        //    using var output = new FileStream(filePath, FileMode.Create);
        //    await mediaBinaryStream.CopyToAsync(output);
        //}

        public async Task SaveProductImageAsync(Stream mediaBinaryStream, string productImageFileName)
        {
            var filePath = Path.Combine(_userContentFolderPath, productImageFileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolderPath, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}