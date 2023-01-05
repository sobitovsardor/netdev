using Netdev.Domain.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Interfaces.Tests
{
    public interface ITestRepository:IGenericRepository<Test>
    {
    }
}
