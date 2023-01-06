using Netdev.Domain.Entities.TestCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Interfaces.TestCategories
{
    public interface ITestCategoryRepository:IGenericRepository<TestCategory>
    {
    }
}
