using Netdev.Domain.Entities.Users;
using Netdev.Service.Dtos;
using Netdev.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserViewModel> GetAllAsync(PaginationParams @params);

        public Task<UserViewModel> GetAsync(long id);

        public Task<bool> DeleteAsync(long id);

        public Task<bool> UpdateAsync(long id, UserCreateDto obj);
    }
}
