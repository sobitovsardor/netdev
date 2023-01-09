using Microsoft.EntityFrameworkCore;
using Netdev.DataAccess.DbContexts;
using Netdev.Domain.Entities.Docs;
using Netdev.Service.Dtos;
using Netdev.Service.Interfaces;

namespace Netdev.Service.Services
{
    public class DocService : IDocsService
    {
        private readonly AppDbContext appDbContext;
        public DocService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> CreateAsync(DocCreatedto dto)
        {
            var entity = (Doc)dto;
            appDbContext.Docs.Add(entity);
            var result = await appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await appDbContext.Docs.FindAsync(id);
            if (entity is not null)
            {
                appDbContext.Docs.Remove(entity);
                var result = await appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new Exception("Document not found");
        }

        public async Task<IEnumerable<Doc>> GetAllAsync()
        {
            return await appDbContext.Docs.AsNoTracking()
            .ToListAsync();
        }

        public async Task<Doc> GetAsync(long id)
        {
            var result = await appDbContext.Docs.FindAsync(id);
            if (result is null) throw new Exception("Document not found");
            else return result;
        }

        public async Task<Doc> GetTaskAsync(string categories)
        {
            var result = await appDbContext.Docs.FindAsync(categories);
            if (result is null) throw new Exception("Document not found");
            else return result;
        }

        public async Task<bool> UpdateAsync(long id, Doc obj)
        {
            var entity = await appDbContext.Docs.FindAsync(id);
            appDbContext.Entry<Doc>(entity!).State = EntityState.Detached;
            if (entity is not null)
            {
                obj.Id = id;
                appDbContext.Docs.Update(obj);
                var result = await appDbContext.SaveChangesAsync();
                return result > 0;
            }
            else throw new Exception("Document not found");
        }
    }
}
