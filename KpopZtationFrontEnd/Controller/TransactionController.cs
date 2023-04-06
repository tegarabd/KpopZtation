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
    public class TransactionController
    {
        private readonly WebService webService;
        private readonly JsonService jsonService;

        private static TransactionController instance;
        private TransactionController()
        {
            webService = WebServiceInstance.GetWebService();
            jsonService = JsonService.GetInstance();
        }

        public static TransactionController GetInstance()
        {
            if (instance == null)
            {
                instance = new TransactionController();
            }
            return instance;
        }

        public void InsertTransaction(Page page, int customerId)
        {
            WebServiceResponse<TransactionHeader> response = jsonService
                .Decode<WebServiceResponse<TransactionHeader>>(webService.InsertTransaction(customerId));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            page.Response.Redirect("~/View/Home.aspx");
        }

        public List<TransactionHeader> GetTransactionsByCustomerId(int customerId)
        {
            WebServiceResponse<List<TransactionHeader>> response = jsonService
                .Decode<WebServiceResponse<List<TransactionHeader>>>(webService.GetTransactionsByCustomerId(customerId));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }
    }
}