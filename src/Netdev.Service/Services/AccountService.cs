using Microsoft.EntityFrameworkCore;
using Netdev.DataAccess.DbContexts;
using Netdev.Domain.Entities.Users;
using Netdev.Service.Dtos;
using Netdev.Service.Exceptions;
using Netdev.Service.Interfaces;
using Netdev.Service.Security;
using System.Net;

namespace Netdev.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _repository;
        private readonly IAuthManager _authManager;

        public AccountService(AppDbContext appDbContext,
            IAuthManager authManager)
        {
            this._repository = appDbContext;
            this._authManager = authManager;
        }

        public async Task<string> LoginAsync(AccountLoginDto dto)
        {
            var user = await _repository.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found, Email is incorrect!");

            var hasherResult = PasswordHasher.Verify(dto.Password, user.PasswordHash, user.Salt);
            if (hasherResult)
            {
                return _authManager.GenerateToken(user);
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Password is invalid!");
        }

        public async Task<bool> RegisterAsync(AccountRegisterDto dto)
        {
            var emailedUser = await _repository.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (emailedUser is not null) throw new Exception("Email already exists");

            var hasherResult = PasswordHasher.Hash(dto.Password);
            var userEntity = (User)dto;
            userEntity.PasswordHash = hasherResult.Hash;
            userEntity.Salt = hasherResult.Salt;
            userEntity.Role = Domain.Enums.UserRole.User;

            _repository.Users.Add(userEntity);
            var dbResult = await _repository.SaveChangesAsync();
            return dbResult > 0;
        }
    }
}