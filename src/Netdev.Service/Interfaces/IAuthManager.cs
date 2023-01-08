using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Interfaces
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
