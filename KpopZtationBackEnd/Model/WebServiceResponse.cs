using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Model
{
    public class WebServiceResponse<T>
    {
        public bool Ok { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
    }
}