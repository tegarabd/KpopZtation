using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Service;
using KpopZtationFrontEnd.View;
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

        private const string SESSION_KEY = "user_session";
        private const string COOKIE_KEY = "user_cookie";
        private const int COOKIE_EXPIRE_IN_HOUR = 1;

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

        public Customer LoginByCookie(MasterPage page)
        {
            if (page.Request.Cookies[COOKIE_KEY] != null)
            {
                int id = Int32.Parse(page.Request.Cookies[COOKIE_KEY].Value);
                WebServiceResponse<Customer> response = jsonService
                    .Decode<WebServiceResponse<Customer>>(webService.GetCustomerById(id));

                if (response.Ok)
                {
                    page.Session[SESSION_KEY] = response.Content;
                    return response.Content;
                }

            }
            return null;
        }

        public void RedirectAuthenticatedPage(Page page)
        {
            if (page.Session[SESSION_KEY] == null && page.Request.Cookies[COOKIE_KEY] == null)
            {
                page.Response.Redirect("~/View/Login.aspx");
                return;
            }
            
            if (page.Request.Cookies[COOKIE_KEY] != null)
            {
                int id = Int32.Parse(page.Request.Cookies[COOKIE_KEY].Value);
                WebServiceResponse<Customer> response = jsonService
                    .Decode<WebServiceResponse<Customer>>(webService.GetCustomerById(id));

                if (!response.Ok)
                {
                    page.Response.Redirect("~/View/Login.aspx");
                    return;
                }

                page.Session[SESSION_KEY] = response.Content;
            }
        }

        public void RedirectUnauthenticatedPage(MasterPage page)
        {
            if (page.Session[SESSION_KEY] != null)
            {
                page.Response.Redirect("~/View/Home.aspx");
            }
        }

        public void Logout(MasterPage page)
        {
            page.Session.Remove(SESSION_KEY);
            string[] keys = page.Request.Cookies.AllKeys;
            foreach (string key in keys)
            {
                page.Response.Cookies.Get(key).Expires = DateTime.Now.AddHours(-COOKIE_EXPIRE_IN_HOUR);
            }
            page.Response.Redirect("~/View/Login.aspx");
        }

        public Customer GetCurrentCustomer(MasterPage page)
        {
            return (Customer) page.Session[SESSION_KEY];
        }

        public bool IsCurrentCustomerAuthorizedByRole(MasterPage page, string role)
        {
            Customer customer = GetCurrentCustomer(page);
            if (customer == null)
            {
                return role == "Guest";
            }
            return customer.CustomerRole == role;
        }

        public void Login(Page page, string username, string password, bool remember)
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

            if (remember)
            {
                HttpCookie cookie = new HttpCookie(COOKIE_KEY)
                {
                    Value = response.Content.CustomerID.ToString(),
                    Expires = DateTime.Now.AddHours(COOKIE_EXPIRE_IN_HOUR)
                };
                page.Response.Cookies.Add(cookie);
            }

            page.Session[SESSION_KEY] = response.Content;
            page.Response.Redirect("~/View/Home.aspx");
        }

        public void Register(MasterPage page, string name, string email, string gender, string address, string password)
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

            page.Response.Redirect("~/View/Login.aspx");
        }
    }
}