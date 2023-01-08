using Netdev.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(AccountRegisterDto dto);

        public Task<string> LoginAsync(AccountLoginDto dto);
    }
}
