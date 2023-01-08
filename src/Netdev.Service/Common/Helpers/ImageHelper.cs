using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netdev.Service.Common.Helpers
{
    public static class ImageHelper
    {
        public static string MakeImageName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string name = "IMG_" + Guid.NewGuid().ToString();
            return name + extension;
        }

    }
}
