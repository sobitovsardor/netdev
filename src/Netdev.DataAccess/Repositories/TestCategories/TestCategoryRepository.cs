using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.TestCategories;
using Netdev.Domain.Entities.TestCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories.TestCategories
{
    public class TestCategoryRepository:GenericRepository<TestCategory>,ITestCategoryRepository
    {
        public TestCategoryRepository(AppDbContext context):base(context)
        {

        }
    }
}
