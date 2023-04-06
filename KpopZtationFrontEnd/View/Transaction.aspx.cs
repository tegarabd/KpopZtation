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
            int customerId = authenticationController.GetCurrentCustomer(Master).CustomerID;
            transactionHeaders = transactionController.GetTransactionsByCustomerId(customerId);
        }
    }
}