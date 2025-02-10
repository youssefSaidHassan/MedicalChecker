using Microsoft.AspNetCore.Http;

namespace MedicalChecker.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFile(string location, IFormFile file);
        void DeleteFile(string filePath);
        byte[] DownloadFile(string filePath);
        Task<bool> IsPdf(IFormFile file);
    }
}
