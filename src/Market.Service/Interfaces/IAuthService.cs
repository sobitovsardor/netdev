using Market.Service.DTOs.UserDtos;

namespace Market.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateJwtTokenAsync(UserViewDto user);
    Task<UserViewDto?> ValidateUserAsync(string email, string password);
} 