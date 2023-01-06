using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Domain.Entities.Users
{
    public class User:Human
    {
        public string PasswordHash { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;
    }
}
