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
    public partial class Profile : System.Web.UI.Page
    {
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        private readonly CustomerController customerController = CustomerController.GetInstance();
        private Customer Customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            authenticationController.RedirectAuthenticatedPage(Page);
            Customer = authenticationController.GetCurrentCustomer(Master);
            if (!IsPostBack)
            {
                TextBoxUsername.Text = Customer.CustomerName;
                TextBoxEmail.Text = Customer.CustomerEmail;
                RadioButtonListGender.SelectedValue = Customer.CustomerGender;
                TextBoxAddress.Text = Customer.CustomerAddress;
                TextBoxPassword.Text = Customer.CustomerPassword;
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LabelResult.Text = "";
            string name = TextBoxUsername.Text;
            string email = TextBoxEmail.Text;
            string gender = RadioButtonListGender.SelectedValue;
            string address = TextBoxAddress.Text;
            string password = TextBoxPassword.Text;

            try
            {
                customerController.UpdateCustomer(Master, Customer.CustomerID, name, email, gender, address, password);
            }
            catch (Exception ex)
            {
                LabelResult.Text = ex.Message;
            }
        }
    }
}