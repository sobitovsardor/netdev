using Netdev.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Interfaces.Account
{
    public interface IAccountService
    {
        public Task<string> LoginAsync(AccountLoginDto dto);
        public Task<bool> RegisterAsync(AccountRegisterDto dto);
    }
}
