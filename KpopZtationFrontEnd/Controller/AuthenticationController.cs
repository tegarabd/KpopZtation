using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Service;
using KpopZtationFrontEnd.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace KpopZtationFrontEnd.Controller
{
    public class AuthenticationController
    {
        private readonly WebService webService;
        private readonly JsonService jsonService;

        private static AuthenticationController instance;

        private const string USER_KEY = "user";

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

        public void RedirectAuthenticatedPage(Page page)
        {
            if (page.Session[USER_KEY] == null)
            {
                page.Response.Redirect("Login.aspx");
            }
        }

        public void RedirectUnauthenticatedPage(Page page)
        {
            if (page.Session[USER_KEY] != null)
            {
                page.Response.Redirect("Home.aspx");
            }
        }

        public void Logout(MasterPage page)
        {
            page.Session[USER_KEY] = null;
            page.Response.Redirect("Login.aspx");
        }

        public void Login(Page page, string username, string password)
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

            page.Session[USER_KEY] = response.Content;
            page.Response.Redirect("Home.aspx");
        }

        public void Register(Page page, string name, string email, string gender, string address, string password)
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

            page.Response.Redirect("Login.aspx");
        }
    }
}