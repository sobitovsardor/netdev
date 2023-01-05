using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.Interviews;
using Netdev.Domain.Entities.Interviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories.Interviews
{
    public class InterviewRepository:GenericRepository<Interview>,IInterviewRepository
    {
        public InterviewRepository(AppDbContext context):base(context)
        {

        }
    }
}
