using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.Users;
using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories.Users
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(AppDbContext context):base(context)
        {

        }
    }
}
