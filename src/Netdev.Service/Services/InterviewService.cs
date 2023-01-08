using Microsoft.EntityFrameworkCore;
using Netdev.DataAccess.DbContexts;
using Netdev.Domain.Entities.Interviews;
using Netdev.Service.Dtos;
using Netdev.Service.Interfaces;

namespace Netdev.Service.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly AppDbContext appDbContext;
        public InterviewService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> CreateAsync(InterviewCreatedto dto)
        {
            var entity = (Interview)dto;
            appDbContext.Interviews.Add(entity);
            var result = await appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await appDbContext.Interviews.FindAsync(id);
            if (entity is not null)
            {
                appDbContext.Interviews.Remove(entity);
                var result = await appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new Exception("Car not found");
        }

        public async Task<IEnumerable<Interview>> GetAllAsync()
        {
            return await appDbContext.Interviews.AsNoTracking()
            .ToListAsync();
        }

        public async Task<Interview> GetAsync(long id)
        {
            var result = await appDbContext.Interviews.FindAsync(id);
            if (result is null) throw new Exception("Car not found");
            else return result;
        }

        public async Task<bool> UpdateAsync(long id, Interview obj)
        {
            var entity = await appDbContext.Interviews.FindAsync(id);
            appDbContext.Entry<Interview>(entity!).State = EntityState.Detached;
            if (entity is not null)
            {
                obj.Id = id;
                appDbContext.Interviews.Update(obj);
                var result = await appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new Exception("Car not found");
        }
    }
}
