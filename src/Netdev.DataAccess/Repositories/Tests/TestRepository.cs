using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.Tests;
using Netdev.Domain.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories.Tests
{
    public class TestRepository:GenericRepository<Test>,ITestRepository
    {
        public TestRepository(AppDbContext context):base(context)
        {

        }
    }
}
