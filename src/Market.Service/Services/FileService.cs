using System.IO;
using Market.Service.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Market.Service.Services;

public class FileService : IFileService
{
    private readonly string _uploadDirectory;
    private readonly string _baseUrl;

    public FileService(IConfiguration configuration)
    {
        _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        _baseUrl = configuration["BaseUrl"] ?? "http://localhost:5000";

        if (!Directory.Exists(_uploadDirectory))
        {
            Directory.CreateDirectory(_uploadDirectory);
        }
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var filePath = Path.Combine(_uploadDirectory, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await fileStream.CopyToAsync(stream);
        }

        return $"{_baseUrl}/uploads/{uniqueFileName}";
    }

    public async Task DeleteFileAsync(string fileUrl)
    {
        if (string.IsNullOrEmpty(fileUrl)) return;

        var fileName = Path.GetFileName(fileUrl);
        var filePath = Path.Combine(_uploadDirectory, fileName);

        if (File.Exists(filePath))
        {
            await Task.Run(() => File.Delete(filePath));
        }
    }
} 