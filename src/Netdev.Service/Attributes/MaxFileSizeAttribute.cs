using Microsoft.AspNetCore.Http;
using Netdev.Service.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Attributes
{
    public class MaxFileSizeAttribute:ValidationAttribute
    {
        private int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                if (FileSizeHelper.ByteToMb(file.Length) > _maxFileSize)
                    return new ValidationResult($"Image must be less than {_maxFileSize} MB");
                else return ValidationResult.Success;
            }
            else return new ValidationResult("The file can not be null!");
        }
    }
}
