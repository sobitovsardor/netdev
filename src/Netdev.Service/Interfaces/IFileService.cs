﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Interfaces
{
    public interface IFileService
    {
        Task<String> SaveImageAsync(IFormFile image);
    }
}
