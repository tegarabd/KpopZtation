using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Dataset;
using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static KpopZtationFrontEnd.Dataset.DataSetReport;

namespace KpopZtationFrontEnd.View
{
    public partial class Reports : System.Web.UI.Page
    {
        private readonly TransactionController transactionController = TransactionController.GetInstance();
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
            {
                Response.Redirect("~/View/Home.aspx");
            }

            List<TransactionHeader> transactionHeaders = transactionController.GetTransactions();
            CrystalReport crystalReport = new CrystalReport();
            DataSetReport dataSetReport = GetDataSetReport(transactionHeaders);
            crystalReport.SetDataSource(dataSetReport);
            CrystalReportViewer.ReportSource = crystalReport;
        }

        private DataSetReport GetDataSetReport(List<TransactionHeader> transactionHeaders)
        {
            DataSetReport dataSetReport = new DataSetReport();
            TransactionHeaderDataTable transactionHeaderRows = dataSetReport.TransactionHeader;
            TransactionDetailDataTable transactionDetailRows = dataSetReport.TransactionDetail;
            PopulateTransactionHeaderTable(transactionHeaders, transactionHeaderRows, transactionDetailRows);

            return dataSetReport;
        }

        private static void PopulateTransactionHeaderTable(List<TransactionHeader> transactionHeaders, TransactionHeaderDataTable transactionHeaderRows, TransactionDetailDataTable transactionDetailRows)
        {
            transactionHeaders.ForEach(transactionHeader =>
            {
                DataRow headerRow = transactionHeaderRows.NewRow();
                headerRow["TransactionID"] = transactionHeader.TransactionID;
                headerRow["CustomerID"] = transactionHeader.CustomerID;
                headerRow["TransactionDate"] = transactionHeader.TransactionDate;
                transactionHeaderRows.Rows.Add(headerRow);
                PopulateTransactionDetailTable(transactionHeader, transactionDetailRows);
            });
        }

        private static void PopulateTransactionDetailTable(TransactionHeader transactionHeader, TransactionDetailDataTable transactionDetailRows)
        {
            transactionHeader.TransactionDetails.ToList().ForEach(transactionDetail =>
            {
                DataRow detailRow = transactionDetailRows.NewRow();
                detailRow["TransactionID"] = transactionDetail.TransactionID;
                detailRow["AlbumID"] = transactionDetail.AlbumID;
                detailRow["Qty"] = transactionDetail.Qty;
                transactionDetailRows.Rows.Add(detailRow);
            });
        }
    }
}