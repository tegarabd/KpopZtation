using KpopZtationFrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.AlbumPage
{
    public partial class Insert : System.Web.UI.Page
    {
        private readonly AlbumController albumController = AlbumController.GetInstance();
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            authenticationController.RedirectAuthenticatedPage(this);
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            LabelResult.Text = "";
            int artistId = Convert.ToInt32(Request.QueryString.Get("artistId"));
            string name = TextBoxAlbumName.Text;
            string description = TextBoxAlbumDescription.Text;
            string price = TextBoxAlbumPrice.Text;
            string stock = TextBoxAlbumStock.Text;
            FileUpload imageFile = FileUploadAlbumImage;

            try
            {
                albumController.InsertAlbum(this, artistId, name, imageFile, description, price, stock);
            }
            catch (Exception ex)
            {
                LabelResult.Text = ex.Message;
                return;
            }

            LabelResult.ForeColor = Color.LightSeaGreen;
            LabelResult.Text = "Successfully insert album";
            TextBoxAlbumName.Text = "";
            TextBoxAlbumDescription.Text = "";
            TextBoxAlbumPrice.Text = "";
            TextBoxAlbumStock.Text = "";
        }
    }
}