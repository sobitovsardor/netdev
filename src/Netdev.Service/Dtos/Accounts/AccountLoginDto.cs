using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {
        [Required, MaxLength(30), MinLength(2), EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MaxLength(8)]
        public string Password { get; set; } = String.Empty;
    }
}
