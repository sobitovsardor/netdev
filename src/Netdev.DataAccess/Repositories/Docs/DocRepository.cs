using Netdev.DataAccess.DbContexts;
using Netdev.DataAccess.Interfaces.Docs;
using Netdev.Domain.Entities.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Repositories.Docs
{
    public class DocRepository:GenericRepository<Doc>,IDocsRepository
    {
        public DocRepository(AppDbContext context) : base(context)
        {

        }

    }
}
