using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Factory
{
    public class CartFactory
    {
        private static CartFactory instance;

        private CartFactory()
        {

        }
        public static CartFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new CartFactory();
            }
            return instance;
        }
        public Cart Create(int customerId, int albumId, int quantity)
        {
            return new Cart()
            {
                AlbumID = albumId,
                CustomerID = customerId,
                Qty = quantity,
            };

        }
    }
}