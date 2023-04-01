using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Factory
{
    public class TransactionFactory
    {
        private static TransactionFactory instance;

        private TransactionFactory()
        {

        }
        public static TransactionFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new TransactionFactory();
            }
            return instance;
        }
        public TransactionHeader CreateHeader(int customerId)
        {
            return new TransactionHeader()
            {
                CustomerID = customerId,
                TransactionDate = DateTime.Now,
            };
        }

        public TransactionDetail CreateDetail(int transactionId, Cart cart)
        {
            return new TransactionDetail()
            {
                TransactionID = transactionId,
                AlbumID = cart.AlbumID,
                Qty = cart.Qty
            };
        }
    }
}