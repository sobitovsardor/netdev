using Market.Service.DTOs.UserDtos;

namespace Market.Service.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserViewDto>> GetAllAsync();
    Task<UserViewDto?> GetByIdAsync(long id);
    Task<UserViewDto> CreateAsync(UserCreateDto dto);
    Task<UserViewDto> UpdateAsync(long id, UserUpdateDto dto);
    Task DeleteAsync(long id);
    Task<UserViewDto?> GetByEmailAsync(string email);
} 