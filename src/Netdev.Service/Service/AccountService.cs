using Microsoft.EntityFrameworkCore;
using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.Account;
using Netdev.DataAccess.Interfaces.Users;
using Netdev.Domain.Entities.Users;
using Netdev.Service.Dtos.Accounts;
using Netdev.Service.Interfaces.Account;
using Netdev.Service.Interfaces.Common.Security;
using Netdev.Service.Service.Common.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Service
{
    public class AccountService : IAccountService
    {
        private AppDbContext _appDbContext;
        private IAuthManagerService _authManagerService;
        private IAccountRepository _accountRepository;
        private IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository,
                              IAuthManagerService authManagerService,
                              IAccountRepository accountRepository,
                              AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _authManagerService = authManagerService;
            _accountRepository = accountRepository;
            _userRepository = userRepository;

        }
        public async Task<string> LoginAsync(AccountLoginDto dto)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user is null)
            {
                return "Email not found";
            }

            var hashResault = PasswordHash.Verify(dto.Password, user.PasswordHash, user.Salt);
            if (hashResault)
            {
                return _authManagerService.GenerateToken(user);
            }
            return "Error";
        }

        public async Task<bool> RegisterAsync(AccountRegisterDto dto)
        {
            var emailUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (emailUser is not null)
            {
                return false;
            }
            var hashResault = PasswordHash.Hash(dto.Password);
            var userEntity = (User)dto;
            userEntity.PasswordHash = hashResault.Hash;
            userEntity.Salt = hashResault.Salt;
            userEntity.Role = Domain.Enums.UserRole.User;
            userEntity.ImagePath = "";

            var resault = await _accountRepository.RegisterAsync(userEntity);
            return resault;
        }
    }
}
