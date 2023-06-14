using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View
{
    public partial class DeleteAccount : System.Web.UI.Page
    {
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        private readonly CustomerController customerController = CustomerController.GetInstance();
        public List<Customer> customers = new List<Customer>();
        public Customer currentCustomer;
        public Customer toBeDeleteCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
            authenticationController.RedirectAuthenticatedPage(Page);
            currentCustomer = authenticationController.GetCurrentCustomer(Master);

            if (Request.QueryString.Get("id") == null)
            {
                if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
                {
                    customers = customerController.GetCustomers();
                    return;
                }

                customers.Add(currentCustomer);
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString.Get("id"));
                toBeDeleteCustomer = customerController.GetCustomerById(id);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/DeleteAccount.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            customerController.DeleteCustomer(toBeDeleteCustomer.CustomerID);

            if (toBeDeleteCustomer.CustomerID == currentCustomer.CustomerID)
            {
                authenticationController.Logout(Master);
            }

            Response.Redirect("/View/DeleteAccount.aspx");
        }
    }
}