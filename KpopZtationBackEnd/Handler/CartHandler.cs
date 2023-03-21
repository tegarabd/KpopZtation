using KpopZtationBackEnd.Model;
using KpopZtationBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Handler
{
    public class CartHandler
    {
        private readonly CartRepository cartRepository = CartRepository.GetInstance();
        private readonly AlbumRepository albumRepository = AlbumRepository.GetInstance();

        public List<Cart> GetCartsByCustomerId(int customerId)
        {
            return cartRepository.GetCartsByCustomerId(customerId);
        }

        public Cart InsertAlbumToCustomerCart(int customerId, int albumId, int quantity)
        {
            Album album = albumRepository.GetAlbumById(albumId);

            if (quantity > album.AlbumStock)
            {
                throw new Exception("Quantity can’t be more than the album stock");
            }

            Cart cart = cartRepository.GetCart(customerId, albumId);

            if (cart != null)
            {
                cart.Qty += quantity;
                cartRepository.UpdateCart(cart);

                return cart;
            }

            cart = new Cart()
            {
                AlbumID = albumId,
                CustomerID = customerId,
                Qty = quantity,
            };

            cartRepository.InsertCart(cart);
            return cart;
        }

    }
}