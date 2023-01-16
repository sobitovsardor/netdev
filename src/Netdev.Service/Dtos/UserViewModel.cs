using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Dtos
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


        public static implicit operator UserViewModel(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                ImagePath = user.ImagePath,
            };
        }
    }
}
