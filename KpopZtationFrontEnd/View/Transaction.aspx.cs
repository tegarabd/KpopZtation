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
    public partial class Transaction : System.Web.UI.Page
    {
        private TransactionController transactionController = TransactionController.GetInstance();
        private AuthenticationController authenticationController = AuthenticationController.GetInstance();

        public List<TransactionHeader> transactionHeaders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Guest"))
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
            {
                transactionHeaders = transactionController.GetTransactions();
                return;
            }

            int customerId = authenticationController.GetCurrentCustomer(Master).CustomerID;
            transactionHeaders = transactionController.GetTransactionsByCustomerId(customerId);
        }
    }
}