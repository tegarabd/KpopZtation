using KpopZtationFrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.ArtistPage
{
    public partial class Insert : System.Web.UI.Page
    {
        private readonly ArtistController artistController = ArtistController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            LabelResult.Text = "";
            string name = TextBoxArtistName.Text;

            try
            {
                artistController.InsertArtist(this, name, FileUploadArtistImage);
            }
            catch (Exception ex)
            {
                LabelResult.Text = ex.Message;
                return;
            }

            LabelResult.ForeColor = Color.LightSeaGreen;
            LabelResult.Text = "Successfully insert artist";
            TextBoxArtistName.Text = "";
        }
    }
}