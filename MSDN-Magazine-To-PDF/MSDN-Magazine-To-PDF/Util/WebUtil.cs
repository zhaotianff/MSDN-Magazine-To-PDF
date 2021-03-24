using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace MSDN_Magazine_To_PDF.Util
{
    public class WebUtil
    {
        public async static Task<string> GetHtml(string url)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }
    }
}
