
namespace Talim.Services;
public class FileService : IFileService
{
    private readonly string _storagePath;

    public FileService(IConfiguration configuration)
    {
        _storagePath = configuration["StoragePath"];
    }

    public async Task<bool> DeleteFileAsync(string filePath)
    {
        var fullPath = Path.Combine(_storagePath, filePath);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }

    public async Task<Stream> GetFileAsync(string filePath)
    {
        var fullPath = Path.Combine(_storagePath, filePath);
        if (File.Exists(fullPath))
        {
            var memoryStream = new MemoryStream();
            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;
            return memoryStream;
        }
        throw new FileNotFoundException("File not found", filePath);
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file.Length > 0)
        {
            string foldername = DateTime.Now.ToString("yyyy-MM");
            var folderFullPath =  Path.Combine(_storagePath,foldername);
            
            if (!Directory.Exists(folderFullPath))
            {
                Directory.CreateDirectory(folderFullPath);
            }
            var fileFullName=Guid.NewGuid().ToString()+"-" + file.FileName;
            var fileFullPath = Path.Combine(folderFullPath,fileFullName);
            using (var stream = new FileStream(fileFullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return await Task.FromResult(foldername+"/"+fileFullName);
        }
        throw new InvalidOperationException("File is empty");

    }
}