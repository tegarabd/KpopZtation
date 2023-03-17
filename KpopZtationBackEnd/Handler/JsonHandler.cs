using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Handler
{
    public class JsonHandler
    {
        public string Encode(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
        }

        public T Decode<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}