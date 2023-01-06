using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces;
using Netdev.DataAccess.Interfaces.Docs;
using Netdev.DataAccess.Interfaces.Interviews;
using Netdev.DataAccess.Interfaces.Statistics;
using Netdev.DataAccess.Interfaces.TestCategories;
using Netdev.DataAccess.Interfaces.Tests;
using Netdev.DataAccess.Interfaces.Users;
using Netdev.DataAccess.Repositories.Docs;
using Netdev.DataAccess.Repositories.Interviews;
using Netdev.DataAccess.Repositories.Statistics;
using Netdev.DataAccess.Repositories.TestCategories;
using Netdev.DataAccess.Repositories.Tests;
using Netdev.DataAccess.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext dbContext;

        public IDocsRepository docsRepository { get; }

        public IInterviewRepository interviewRepository { get; }

        public IStatisticRepository statisticRepository { get; }

        public ITestCategoryRepository testCategoryRepository { get; }

        public ITestRepository testRepository { get; }

        public IUserRepository userRepository { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
            docsRepository = new DocRepository(appDbContext);
            interviewRepository = new InterviewRepository(appDbContext);
            statisticRepository = new StatisticRepository(appDbContext);
            testCategoryRepository = new TestCategoryRepository(appDbContext);
            testRepository = new TestRepository(appDbContext);
            userRepository = new UserRepository(appDbContext);

        }

        public async Task<int> SaveChangesAsync()
        {

            return await dbContext.SaveChangesAsync();
        }
    }
}
