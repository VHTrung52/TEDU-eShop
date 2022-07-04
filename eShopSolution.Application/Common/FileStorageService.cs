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
            _userContentFolderPath = Path.Combine(webHostEnvironment.WebRootPath, _configuration["UserContentFolder"]);
        }

        public string GetFileUrl(string fileName)
        {
            if(fileName == null)
                return string.Empty;

            var filePath = Path.Combine(_userContentFolderPath, fileName);
            if (!File.Exists(filePath))
                return string.Empty;

            return $"{_configuration["BaseAddress"]}/{_configuration["UserContentFolder"]}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolderPath, fileName);
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