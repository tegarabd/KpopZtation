using KpopZtationBackEnd.Factory;
using KpopZtationBackEnd.Model;
using KpopZtationBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Handler
{
    public class TransactionHandler
    {
        private readonly TransactionRepository transactionRepository = TransactionRepository.GetInstance();
        private readonly TransactionFactory transactionFactory = TransactionFactory.GetInstance();
        private readonly CartRepository cartRepository = CartRepository.GetInstance();
        private readonly AlbumRepository albumRepository = AlbumRepository.GetInstance();

        public TransactionHeader InsertTransaction(int customerId)
        {
            List<Cart> carts = cartRepository.GetCartsByCustomerId(customerId);
            TransactionHeader transactionHeader = InsertTransactionHeader(customerId);
            List<TransactionDetail> transactionDetails = GenerateTransactionDetails(carts, transactionHeader);
            InsertTransactionDetails(ref transactionDetails);
            DeleteUserCarts(ref carts);
            UpdateAlbumStock(ref carts);

            return transactionHeader;
        }

        private void InsertTransactionDetails(ref List<TransactionDetail> transactionDetails)
        {
            transactionRepository.InsertTransactionDetails(transactionDetails);
        }

        private void DeleteUserCarts(ref List<Cart> carts)
        {
            cartRepository.DeleteCarts(carts);
        }

        private void UpdateAlbumStock(ref List<Cart> carts)
        {
            carts.ForEach(cart =>
            {
                Album album = albumRepository.GetAlbumById(cart.AlbumID);
                album.AlbumStock -= cart.Qty;
                albumRepository.UpdateAlbum(album);
            });
        }

        private List<TransactionDetail> GenerateTransactionDetails(List<Cart> carts, TransactionHeader transactionHeader)
        {
            return carts.Select(cart => transactionFactory.CreateDetail(transactionHeader.TransactionID, cart)).ToList();
        }

        private TransactionHeader InsertTransactionHeader(int customerId)
        {
            TransactionHeader transactionHeader = transactionFactory.CreateHeader(customerId);
            transactionHeader = transactionRepository.InsertTransactionHeader(transactionHeader);
            return transactionHeader;
        }

        public List<TransactionHeader> GetTransactions()
        {
            return transactionRepository.GetTransactionHeaders();
        }

        public List<TransactionHeader> GetTransactionsByCustomerId(int customerId)
        {
            return transactionRepository.GetTransactionHeadersByCustomerId(customerId);
        }
    }
}