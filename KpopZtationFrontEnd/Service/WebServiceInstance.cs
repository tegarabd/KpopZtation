using KpopZtationFrontEnd.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationFrontEnd.Service
{
    public class WebServiceInstance
    {
        private static WebService service;

        private WebServiceInstance()
        {

        }

        public static WebService GetWebService()
        {
            if (service == null)
            {
                service = new WebService();
            }
            return service;
        }
    }
}