using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.ArtistPage
{
    public partial class Update : System.Web.UI.Page
    {
        private readonly ArtistController artistController = ArtistController.GetInstance();
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString.Get("id"));
                Artist Artist = artistController.GetArtistById(id);
                TextBoxArtistName.Text = Artist.ArtistName;
                ImageArtist.ImageUrl = "~/Assets/Artists/" + Artist.ArtistImage;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            LabelResult.Text = "";
            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            string name = TextBoxArtistName.Text;
            FileUpload fileImage = FileUploadArtistImage;

            try
            {
                artistController.UpdateArtist(this, id, name, fileImage);
            }
            catch (Exception ex)
            {
                LabelResult.ForeColor = Color.Red;
                LabelResult.Text = ex.Message;
                return;
            }

            LabelResult.ForeColor = Color.LightSeaGreen;
            LabelResult.Text = "Successfully update artist";
            ImageArtist.ImageUrl = "~/Assets/Artists/" + fileImage.FileName;
        }
    }
}