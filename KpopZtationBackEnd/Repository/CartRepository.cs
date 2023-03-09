using KpopZtationBackEnd.Database;
using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Repository
{
    public class CartRepository
    {
        private readonly DatabaseEntities Db;
        private static CartRepository instance;

        private CartRepository()
        {
            Db = DatabaseInstance.GetDb();
        }

        public static CartRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CartRepository();
            }
            return instance;
        }

        public List<Cart> GetCartsByCustomerId(int id)
        {
            return Db.Carts.Where(cart => cart.CustomerID == id).ToList();
        }
    }
}