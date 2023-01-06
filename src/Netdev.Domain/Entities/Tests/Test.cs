using Netdev.Domain.Common;
using Netdev.Domain.Entities.TestCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Domain.Entities.Tests
{
    public class Test : Auditable
    {
        public string Questions { get; set; } = string.Empty;

        public string Answer1 { get; set; } = string.Empty;

        public string Answer2 { get; set; } = string.Empty;

        public string Answer3 { get; set; } = string.Empty;

        public string Answer4 { get; set; } = string.Empty;

        public long CategoryId { get; set; }
        public virtual TestCategory TestCategory { get; set; } = default!;
    }
}
