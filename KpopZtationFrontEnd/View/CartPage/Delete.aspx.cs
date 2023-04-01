using KpopZtationFrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.CartPage
{
    public partial class Delete : System.Web.UI.Page
    {
        private readonly CartController cartController = CartController.GetInstance();
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Customer"))
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            int albumId = Convert.ToInt32(Request.QueryString.Get("albumId"));
            int customerId = authenticationController.GetCurrentCustomer(Master).CustomerID;
            cartController.DeleteCart(this, customerId, albumId);
        }
    }
}