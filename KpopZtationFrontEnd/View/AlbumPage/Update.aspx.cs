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
    public partial class Update : System.Web.UI.Page
    {
        private readonly AlbumController albumController = AlbumController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString.Get("id"));
                Album Album = albumController.GetAlbumById(id);
                TextBoxAlbumName.Text = Album.AlbumName;
                TextBoxAlbumDescription.Text = Album.AlbumDescription;
                TextBoxAlbumPrice.Text = Album.AlbumPrice.ToString();
                TextBoxAlbumStock.Text = Album.AlbumStock.ToString();
                ImageAlbum.ImageUrl = "~/Assets/Albums/" + Album.AlbumImage;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            LabelResult.Text = "";
            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            string name = TextBoxAlbumName.Text;
            string description = TextBoxAlbumDescription.Text;
            string price = TextBoxAlbumPrice.Text;
            string stock = TextBoxAlbumStock.Text;
            FileUpload imageFile = FileUploadAlbumImage;

            try
            {
                albumController.UpdateAlbum(this, id, name, imageFile, description, price, stock);
            }
            catch (Exception ex)
            {
                LabelResult.Text = ex.Message;
                return;
            }

            LabelResult.ForeColor = Color.LightSeaGreen;
            LabelResult.Text = "Successfully update album";
            ImageAlbum.ImageUrl = "~/Assets/Albums/" + imageFile.FileName;
        }
    }
}