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
    public partial class NavBar : System.Web.UI.MasterPage
    {
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer = authenticationController.LoginByCookie(this);
            ChangeNavVisibilityByRole(customer);
        }

        private void ChangeNavVisibilityByRole(Customer customer)
        {
            if (authenticationController.IsCurrentCustomerAuthorizedByRole(this, "Guest"))
            {
                NavLogin.Visible = true;
                NavRegister.Visible = true;
            }

            if (authenticationController.IsCurrentCustomerAuthorizedByRole(this, "Admin") ||
                authenticationController.IsCurrentCustomerAuthorizedByRole(this, "Customer"))
            {
                LabelUsername.Text = customer?.CustomerName;
                NavTransaction.Visible = true;
                NavProfile.Visible = true;
                NavLogout.Visible = true;
            }

            if (authenticationController.IsCurrentCustomerAuthorizedByRole(this, "Customer"))
            {
                NavCart.Visible = true;
            }
        }

        protected void Nav_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string page = button.ID.Replace("Nav", "~/View/") + ".aspx";
            Response.Redirect(page);
        }

        protected void NavLogout_Click(object sender, EventArgs e)
        {
            authenticationController.Logout(this);
        }

    }
}