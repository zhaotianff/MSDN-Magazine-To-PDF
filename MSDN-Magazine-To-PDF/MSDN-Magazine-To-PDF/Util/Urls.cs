using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDN_Magazine_To_PDF.Util
{
    public class Urls
    {
        public const string BaseUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/";

        /// <summary>
        /// Get the total list
        /// </summary>
        public const string GetListUrl = "https://docs.microsoft.com/en-us/archive/msdn-magazine/toc.json";

        /// <summary>
        /// Get the list of each year
        /// </summary>
        public const string GetYearContent = "https://docs.microsoft.com/en-us/archive/msdn-magazine/{0}/toc.json";
    }
}
