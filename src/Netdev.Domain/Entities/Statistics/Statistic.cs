using Netdev.Domain.Common;
using Netdev.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Domain.Entities.Statistics
{
    public class Statistic: BaseEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;

        public  string Category { get; set; } = string.Empty;

        public string TrueAnswer { get; set; } = string.Empty;

        public string FalseAnswer { get; set; } = string.Empty;

        public DateTime TimeClose { get; set; }
    }
}
