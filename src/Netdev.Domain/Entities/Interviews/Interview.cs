using Netdev.Domain.Common;
using Netdev.Domain.Entities.TestCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Domain.Entities.Interviews
{
    public class Interview:Auditable
    {
        public string Qestion { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;

        public int Rating { get; set; }

        public long CategoryId { get; set; }
        public virtual TestCategory TestCategory { get; set; } = default!;
    }
}
