using Market.DataAccess.Data;
using Market.DataAccess.Repositories;
using Market.Domain.Entities;
using Market.Domain.Enums;
using Market.Service.DTOs.UserDtos;
using Market.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Market.Service.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IGenericRepository<User> _userRepository;

    public UserService(AppDbContext context, IGenericRepository<User> userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserViewDto>> GetAllAsync()
    {
        var users = await _context.Users
            .Where(u => !u.IsDeleted)
            .ToListAsync();

        return users.Select(u => new UserViewDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            Address = u.Address,
            Role = u.Role,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt
        });
    }

    public async Task<UserViewDto?> GetByIdAsync(long id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);

        if (user == null) return null;

        return new UserViewDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    public async Task<UserViewDto> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = HashPassword(dto.Password),
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            Role = UserRole.User // Default role
        };

        await _userRepository.AddAsync(user);

        var createdUser = await _context.Users
            .FirstAsync(u => u.Id == user.Id);

        return new UserViewDto
        {
            Id = createdUser.Id,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            Email = createdUser.Email,
            PhoneNumber = createdUser.PhoneNumber,
            Address = createdUser.Address,
            Role = createdUser.Role,
            CreatedAt = createdUser.CreatedAt,
            UpdatedAt = createdUser.UpdatedAt
        };
    }

    public async Task<UserViewDto> UpdateAsync(long id, UserUpdateDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.PhoneNumber = dto.PhoneNumber;
        user.Address = dto.Address;

        await _userRepository.UpdateAsync(user);

        var updatedUser = await _context.Users
            .FirstAsync(u => u.Id == id);

        return new UserViewDto
        {
            Id = updatedUser.Id,
            FirstName = updatedUser.FirstName,
            LastName = updatedUser.LastName,
            Email = updatedUser.Email,
            PhoneNumber = updatedUser.PhoneNumber,
            Address = updatedUser.Address,
            Role = updatedUser.Role,
            CreatedAt = updatedUser.CreatedAt,
            UpdatedAt = updatedUser.UpdatedAt
        };
    }

    public async Task DeleteAsync(long id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<UserViewDto?> GetByEmailAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);

        if (user == null) return null;

        return new UserViewDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
} 