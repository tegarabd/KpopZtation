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
    public class CustomerController
    {
        private readonly WebService webService;
        private readonly JsonService jsonService;

        private static CustomerController instance;
        private CustomerController()
        {
            webService = WebServiceInstance.GetWebService();
            jsonService = JsonService.GetInstance();
        }

        public static CustomerController GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerController();
            }
            return instance;
        }

        public Customer GetCustomerById(int id)
        {
            WebServiceResponse<Customer> response = jsonService
                .Decode<WebServiceResponse<Customer>>(webService.GetCustomerById(id));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }

        public void UpdateCustomer(MasterPage page, int id, string name, string email, string gender, string address, string password)
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
                .Decode<WebServiceResponse<Customer>>(webService.UpdateCustomer(id, name, email, gender, address, password));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            page.Response.Redirect("~/View/Home.aspx");
        }

    }
}