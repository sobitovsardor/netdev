using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.Statistics;
using Netdev.Domain.Entities.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories.Statistics
{
    public class StatisticRepository:GenericRepository<Statistic>,IStatisticRepository
    {
        public StatisticRepository(AppDbContext context):base(context)
        {

        }
    }
}
