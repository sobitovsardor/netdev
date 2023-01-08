using Netdev.Domain.Common;
using Netdev.Domain.Entities.TestCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Domain.Entities.Docs
{
    public class Doc:Auditable
    {
        public string Title { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
