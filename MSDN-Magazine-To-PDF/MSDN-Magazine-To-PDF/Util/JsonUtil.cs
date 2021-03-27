using System;
using Newtonsoft.Json;

namespace MSDN_Magazine_To_PDF.Util
{
    public class JsonUtil
    {
        public T Desc<T>(string json) where T : class, new()
        {
            try
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore,MissingMemberHandling = MissingMemberHandling.Ignore };
                return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
