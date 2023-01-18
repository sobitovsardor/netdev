using Microsoft.EntityFrameworkCore;
using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces;
using Netdev.DataAccess.Interfaces.Users;
using Netdev.DataAccess.Repositories;
using Netdev.Domain.Entities.Users;
using Netdev.Service.Dtos;
using Netdev.Service.Interfaces;
using Netdev.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _appDbContext;
        private readonly IFileService _fileService;

        public UserService(AppDbContext appDbContext ,IFileService fileService,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appDbContext = appDbContext;
            _fileService = fileService;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _appDbContext.Users.FindAsync(id);
            if (entity is not null)
            {
                _appDbContext.Users.Remove(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new Exception("User not found");

        }

        public  IEnumerable<UserViewModel> GetAllAsync(PaginationParams @params)
        {
            var users = ( _unitOfWork.userRepository.GetAll()).Skip(@params.SkipCount()).Take(@params.PageSize).AsNoTracking().ToList();
            var userViews = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userView = new UserViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    ImagePath = "https:\\localhost:7066" + user.ImagePath,
                    UserName = user.UserName,

                };
                userViews.Add(userView);
            }
            return  userViews;
        }

        public async Task<UserViewModel> GetAsync(long id)
        {
            var result = await _appDbContext.Users.FindAsync(id);
            if (result is null) throw new Exception("User not found");
            else return result;
        }

        public async Task<bool> UpdateAsync(long id, UserCreateDto obj)
        {
            var entity = await _appDbContext.Users.FindAsync(id);
            _appDbContext.Entry<User>(entity!).State = EntityState.Detached;
            var imagePath = await _fileService.SaveImageAsync(obj.Image);
            if (entity is not null)
            {
                entity.Id = id;
                entity.Email = obj.Email;
                entity.ImagePath = imagePath;
                entity.UserName = obj.UserName;
               
                _appDbContext.Users.Update(entity);
                var result = await _appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new Exception("User not found");
        }
    }
}
