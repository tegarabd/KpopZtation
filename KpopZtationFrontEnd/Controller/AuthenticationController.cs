using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Service;
using KpopZtationFrontEnd.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationFrontEnd.Controller
{
    public class AuthenticationController
    {
        private readonly WebService webService;
        private readonly JsonService jsonService;

        private static AuthenticationController instance;

        private AuthenticationController()
        {
            webService = WebServiceInstance.GetWebService();
            jsonService = JsonService.GetInstance();
        }

        public static AuthenticationController GetInstance()
        {
            if (instance == null)
            {
                instance = new AuthenticationController();
            }
            return instance;
        }
        public Customer Login(string username, string password)
        {
            if (username.Equals("") || password.Equals(""))
            {
                throw new Exception("All field must be filled");
            }

            WebServiceResponse<Customer> response = jsonService
                .Decode<WebServiceResponse<Customer>>(webService.Login(username, password));
            
            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }
    }
}