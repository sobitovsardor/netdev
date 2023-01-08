using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Dtos
{
    public class AccountLoginDto
    {
        [Required, MaxLength(20), MinLength(3), EmailAddress]
        public string Email { get; set; } = String.Empty;

        [Required, MinLength(8)]
        public string Password { get; set; } = String.Empty;
    }
}
