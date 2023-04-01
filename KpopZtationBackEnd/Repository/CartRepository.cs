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

        public List<Cart> GetCartsByCustomerId(int customerId)
        {
            return Db.Carts.Where(cart => cart.CustomerID == customerId).ToList();
        }

        public void InsertCart(Cart cart)
        {
            Db.Carts.Add(cart);
            Db.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            Cart updatedCart = GetCart(cart.CustomerID, cart.AlbumID);
            updatedCart.Qty = cart.Qty;
            Db.SaveChanges();
        }

        public Cart GetCart(int customerId, int albumId)
        {
            return Db.Carts.Where(cart => cart.CustomerID == customerId && cart.AlbumID == albumId).FirstOrDefault();
        }

        public void DeleteCart(Cart cart)
        {
            Db.Carts.Remove(cart);
            Db.SaveChanges();
        }

        public void DeleteCarts(List<Cart> carts)
        {
            Db.Carts.RemoveRange(carts);
            Db.SaveChanges();
        }
    }
}