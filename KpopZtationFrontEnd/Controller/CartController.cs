using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Service;
using KpopZtationFrontEnd.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationFrontEnd.Controller
{
    public class CartController
    {
        private readonly WebService webService;
        private readonly JsonService jsonService;

        private static CartController instance;
        private CartController()
        {
            webService = WebServiceInstance.GetWebService();
            jsonService = JsonService.GetInstance();
        }

        public static CartController GetInstance()
        {
            if (instance == null)
            {
                instance = new CartController();
            }
            return instance;
        }

        public void InsertAlbumToCustomerCart(int customerId, int albumId, string quantity)
        {
            if (quantity.Equals(""))
            {
                throw new Exception("Quantity must be filled");
            }

            int quantityAsInt = Convert.ToInt32(quantity);
            WebServiceResponse<Cart> response = jsonService
                .Decode<WebServiceResponse<Cart>>(webService.InsertAlbumToCustomerCart(customerId, albumId, quantityAsInt));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }
        }

        public List<Cart> GetCartsByCustomerId(int customerId)
        {
            WebServiceResponse<List<Cart>> response = jsonService
                .Decode<WebServiceResponse<List<Cart>>>(webService.GetCartsByCustomerId(customerId));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }

    }
}