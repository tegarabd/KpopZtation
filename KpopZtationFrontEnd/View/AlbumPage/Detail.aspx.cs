using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.AlbumPage
{
    public partial class Detail : System.Web.UI.Page
    {
        private AlbumController albumController = AlbumController.GetInstance();
        private CartController cartController = CartController.GetInstance();
        public AuthenticationController authenticationController = AuthenticationController.GetInstance();
        public Album album;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            album = albumController.GetAlbumById(id);
        }

        protected void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            LabelResult.Text = "";
            int customerId = authenticationController.GetCurrentCustomer(Master).CustomerID;
            int albumId = Convert.ToInt32(Request.QueryString.Get("id"));
            string quantity = TextBoxQuantity.Text;

            try
            {
                cartController.InsertAlbumToCustomerCart(customerId, albumId, quantity);
            }
            catch (Exception ex)
            {
                LabelResult.ForeColor = Color.Red;
                LabelResult.Text = ex.Message;
                return;
            }

            LabelResult.ForeColor = Color.LightSeaGreen;
            LabelResult.Text = "Successfully insert album to cart";
        }
    }
}