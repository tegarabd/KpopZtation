using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationFrontEnd.Service
{
    public class JsonService
    {
        private static JsonService instance;

        private JsonService()
        {
            
        }

        public static JsonService GetInstance()
        {
            if (instance == null)
            {
                instance = new JsonService();
            }
            return instance;
        }

        public string Encode(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public T Decode<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}