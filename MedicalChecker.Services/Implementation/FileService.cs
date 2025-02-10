using MedicalChecker.Services.Interfaces;
using MedicalChecker.Utility.AppMetaData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MedicalChecker.Services.Implementation
{
    public class FileService : IFileService
    {

        #region Fields
        private readonly IWebHostEnvironment _webHostEnvironment;

        #endregion

        #region Constructor
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        #endregion

        #region Handel Functions
        public void DeleteFile(string filePath)
        {
            var path = _webHostEnvironment.WebRootPath + filePath;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                throw new FileNotFoundException("File not found.");
            }
        }

        public byte[] DownloadFile(string filePath)
        {
            var path = _webHostEnvironment.WebRootPath + filePath;
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                throw new FileNotFoundException("File not found.");
            }
        }

        public Task<bool> IsPdf(IFormFile file)
        {
            var mimeType = file.ContentType;
            var result = mimeType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase);
            return Task.FromResult(result);
        }
        public async Task<string> UploadFile(string location, IFormFile file)
        {
            var path = _webHostEnvironment.WebRootPath + "/" + location + "/";
            if (file.Length > 0)
            {
                try
                {
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString() + extension;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return $"/{location}/{fileName}";
                    }
                }
                catch (Exception ex)
                {

                    return SD.FailedToUploadFile;
                }
            }
            return SD.NoFile;
        }
        #endregion
    }
}
