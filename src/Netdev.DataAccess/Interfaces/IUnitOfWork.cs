using Netdev.DataAccess.Interfaces.Docs;
using Netdev.DataAccess.Interfaces.Interviews;
using Netdev.DataAccess.Interfaces.Statistics;
using Netdev.DataAccess.Interfaces.TestCategories;
using Netdev.DataAccess.Interfaces.Tests;
using Netdev.DataAccess.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IDocsRepository docsRepository { get; }

        public IInterviewRepository interviewRepository { get; }

        public IStatisticRepository statisticRepository { get; }

        public ITestCategoryRepository testCategoryRepository { get; }

        public ITestRepository testRepository { get; }

        public IUserRepository userRepository { get; }

        public Task<int> SaveChangesAsync();
    }
}
