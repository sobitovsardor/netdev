using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.Account;
using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories.Account
{
    public class AccountRepository:GenericRepository<User>,IAccountRepository
    {
        public AccountRepository(AppDbContext context):base(context)
        {

        }
    }
}
