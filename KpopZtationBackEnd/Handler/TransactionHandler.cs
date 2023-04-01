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

            // Insert Transaction Header
            TransactionHeader transactionHeader = transactionFactory.CreateHeader(customerId);
            transactionHeader = transactionRepository.InsertTransactionHeader(transactionHeader);

            // Generate Transaction Details
            List<TransactionDetail> transactionDetails = carts.Select(cart => transactionFactory.CreateDetail(transactionHeader.TransactionID, cart)).ToList();

            // Update Album Stock
            carts.ForEach(cart =>
            {
                Album album = cart.Album;
                album.AlbumStock -= cart.Qty;
                albumRepository.UpdateAlbum(album);
            });

            // Insert Transaction Details and Delete Carts
            transactionRepository.InsertTransactionDetails(transactionDetails);
            cartRepository.DeleteCarts(carts);

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