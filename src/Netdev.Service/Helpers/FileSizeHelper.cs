using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Helpers
{
    public class FileSizeHelper
    {
        public static double ByteToMb(double @byte)
        {
            return @byte / 1024 / 1024;
        }
    }
}
