using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required, MaxLength(30), MinLength(2)]
        public string UserName { get; set; } = String.Empty;
       
        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = String.Empty;

        public static implicit operator User(AccountRegisterDto dto)
        {
            return new User()
            {
                UserName = dto.UserName,
                Email = dto.Email
            };
        }
    }
}
