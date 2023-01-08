using Netdev.Domain.Entities.Docs;
using Netdev.Domain.Entities.Interviews;
using Netdev.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Interfaces
{
    public interface IInterviewService
    {
        public Task<IEnumerable<Interview>> GetAllAsync();

        public Task<Interview> GetAsync(long id);

        public Task<bool> DeleteAsync(long id);

        public Task<bool> CreateAsync(InterviewCreatedto dto);

        public Task<bool> UpdateAsync(long id, Interview obj);
    }
}
