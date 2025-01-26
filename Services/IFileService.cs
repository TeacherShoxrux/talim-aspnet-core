namespace Talim.Services;
public interface IFileService
{
    Task<string> UploadFileAsync(IFormFile file);
    Task<bool> DeleteFileAsync(string filePath);
    Task<Stream> GetFileAsync(string filePath);
}