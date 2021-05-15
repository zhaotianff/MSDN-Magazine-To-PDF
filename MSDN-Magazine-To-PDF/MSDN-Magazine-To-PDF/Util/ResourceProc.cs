using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDN_Magazine_To_PDF.Util
{
    public class ResourceProc
    {
        public static System.Windows.Style TryFindLocalStyle(string key)
        {
            var resource = System.Windows.Application.Current.TryFindResource(key);

            if (resource == null)
                return null;

            return resource as System.Windows.Style;
        }
    }
}
