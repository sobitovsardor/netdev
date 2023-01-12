using Microsoft.AspNetCore.Http;
using Netdev.Service.Helpers;
using Netdev.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Services
{
    public class FileService : IFileService
    {
        //private readonly string _basePath = string.Empty;
        //private const string _folderName = "images";

        //public FileService(IWebHostEnvironment webHostEnvironment)
        //{
        //    _basePath = webHostEnvironment.ContentRootPath;
        //}

        //public async Task<string> SaveImageAsync(IFormFile image)
        //{
        //    string fileName = ImageHelper.MakeImageName(image.FileName);
        //    string partPath = Path.Combine(_folderName, fileName);
        //    string path = Path.Combine(_basePath, "wwwroot", partPath);

        //    var stream = File.Create(path);
        //    await image.CopyToAsync(stream);

        //    return partPath;
        //}
    }
}
