using Netdev.Domain.Common;
using Netdev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Domain.Entities
{
    public class Human:Auditable
    {
        public string UserName { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime RegisterDateTime { get; set; }
        
        public UserRole Role { get; set; }
    }
}
