using Microsoft.AspNetCore.Http;
using Netdev.Domain.Entities.Users;
using Netdev.Service.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Dtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
                    ErrorMessage = "Please enter valid  Username. " +
                    "Username must be contains only letters or ' character")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                    ErrorMessage = "Please enter valid email")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5)]
        [AllowedFileExtensionAttribute(new string[] { ".jpg", ".png", ".ico" })]
        public IFormFile Image { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        [StrongPasswordAttribute]
        public string Password { get; set; } = string.Empty;


        public static explicit operator User(UserCreateDto userCreateDto)
        {
            return new User()
            {
                UserName = userCreateDto.UserName,  
                Email = userCreateDto.Email,

            };
        }
    }
}
