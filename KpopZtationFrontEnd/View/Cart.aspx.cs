using KpopZtationFrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View
{
    public partial class Cart : System.Web.UI.Page
    {
        private CartController cartController = CartController.GetInstance();
        private AuthenticationController authenticationController = AuthenticationController.GetInstance();

        public List<Model.Cart> carts;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Customer"))
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            int customerId = authenticationController.GetCurrentCustomer(Master).CustomerID;
            carts = cartController.GetCartsByCustomerId(customerId);
        }


    }
}