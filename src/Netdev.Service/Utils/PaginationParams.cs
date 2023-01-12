using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Utils
{
    public class PaginationParams
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int SkipCount()
            => (PageIndex - 1) * PageSize;
    }
}
