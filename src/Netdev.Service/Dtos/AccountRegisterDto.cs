using Netdev.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace Netdev.Service.Dtos;

public class AccountRegisterDto
{
    [Required, MaxLength(20), MinLength(3)]
    public string UserName { get; set; } = String.Empty;

    [Required, MaxLength(30), MinLength(3), EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required, MinLength(8)]
    public string Password { get; set; } = String.Empty;


    public static implicit operator User(AccountRegisterDto dto)
    {
        return new User()
        {
            UserName = dto.UserName,
            Email = dto.Email
        };
    }
}
