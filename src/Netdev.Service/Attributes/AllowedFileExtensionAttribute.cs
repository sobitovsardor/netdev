﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Attributes
{
    internal class AllowedFileExtensionAttribute:ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedFileExtensionAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (_extensions.Contains(extension.ToLower()))
                    return ValidationResult.Success;
                else return new ValidationResult("This file extension is not supperted!");
            }
            else return new ValidationResult("File can not be null!");
        }
    }
}
