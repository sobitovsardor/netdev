using Netdev.Domain.Entities.Docs;
using Netdev.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Interfaces
{
    public interface IDocsService
    {
        public Task<IEnumerable<Doc>> GetAllAsync();

        public Task<Doc> GetAsync(long id);

        public Task<bool> DeleteAsync(long id);

        public Task<bool> CreateAsync(DocCreatedto dto);

        public Task<bool> UpdateAsync(long id, Doc obj);
    }
}
