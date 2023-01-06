using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Interfaces.Users
{
    public interface IUserRepository:IGenericRepository<User>
    {
    }
}
