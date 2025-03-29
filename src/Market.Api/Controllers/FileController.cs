using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Market.Service.Interfaces;

namespace Market.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("upload")]
    public async Task<ActionResult<string>> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!allowedExtensions.Contains(fileExtension))
            return BadRequest("Invalid file type. Only JPG, JPEG, PNG, and GIF files are allowed.");

        var fileUrl = await _fileService.UploadFileAsync(
            file.OpenReadStream(),
            file.FileName,
            file.ContentType
        );

        return Ok(new { url = fileUrl });
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{fileUrl}")]
    public async Task<ActionResult> DeleteFile(string fileUrl)
    {
        await _fileService.DeleteFileAsync(fileUrl);
        return NoContent();
    }
} 