using Netdev.Domain.Entities.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.DataAccess.Interfaces.Docs
{
    public interface IDocsRepository:IGenericRepository<Doc>
    {
        Task<Doc> SortByCategoryDocs(string category);
    }
}
