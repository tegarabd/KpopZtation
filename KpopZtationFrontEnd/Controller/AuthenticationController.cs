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

        public Customer Register(string name, string email, string gender, string address, string password)
        {
            if (name.Equals("") || email.Equals("") || gender.Equals("") || address.Equals("") || password.Equals(""))
            {
                throw new Exception("All field must be filled");
            }

            if (name.Length < 5 || name.Length > 50)
            {
                throw new Exception("Name must be 5 - 50 characters");
            }

            if (gender.Equals(""))
            {
                throw new Exception("Gender must be selected");
            }

            if (!address.EndsWith("Street"))
            {
                throw new Exception("Address must be ends with 'Street'");
            }

            if (!(password.Any(Char.IsLetter) && password.Any(Char.IsDigit)))
            {
                throw new Exception("Password must be alphanumeric");
            }

            WebServiceResponse<Customer> response = jsonService
                .Decode<WebServiceResponse<Customer>>(webService.Register(name, email, gender, address, password));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }
    }
}