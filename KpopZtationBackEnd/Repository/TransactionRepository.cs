using KpopZtationBackEnd.Database;
using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Repository
{
    public class TransactionRepository
    {
        private readonly DatabaseEntities Db;
        private static TransactionRepository instance;

        private TransactionRepository()
        {
            Db = DatabaseInstance.GetDb();
        }
        public static TransactionRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new TransactionRepository();
            }
            return instance;
        }

        public List<TransactionHeader> GetTransactionHeaders()
        {
            return Db.TransactionHeaders.ToList();
        }

        public List<TransactionHeader> GetTransactionHeadersByCustomerId(int id)
        {
            return Db.TransactionHeaders.Where(transaction => transaction.CustomerID == id).ToList();
        }

        public TransactionHeader GetTransactionHeaderById(int id)
        {
            return Db.TransactionHeaders.Where(transaction => transaction.TransactionID == id).FirstOrDefault();
        }

        public List<TransactionDetail> GetTransactionDetailsByTransactionId(int id)
        {
            return Db.TransactionDetails.Where(transaction => transaction.TransactionID == id).ToList();
        }

        public TransactionHeader InsertTransactionHeader(TransactionHeader transactionHeader)
        {
            TransactionHeader transaction = Db.TransactionHeaders.Add(transactionHeader);
            Db.SaveChanges();
            return transaction;
        }

        public void InsertTransactionDetails(List<TransactionDetail> transactionDetails)
        {
            Db.TransactionDetails.AddRange(transactionDetails);
            Db.SaveChanges();
        }
    }
}