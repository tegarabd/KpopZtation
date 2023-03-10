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
        private AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer customer = (Customer) Session["user"];
            if (customer == null)
            {
                NavLogin.Visible = true;
                NavRegister.Visible = true;
            }
            else
            {
                NavLogout.Visible = true;

                switch (customer.CustomerRole)
                {
                    case "Guest":
                        break;
                    case "Customer":
                        break;
                    case "Admin":
                        break;
                }

            }
        }

        protected void NavLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void NavRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void NavLogout_Click(object sender, EventArgs e)
        {
            authenticationController.Logout(this);
        }
    }
}