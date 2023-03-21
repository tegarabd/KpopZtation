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
        private readonly AuthenticationController authenticationController = AuthenticationController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }
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
                LabelResult.ForeColor = Color.Red;
                LabelResult.Text = ex.Message;
                return;
            }

            LabelResult.ForeColor = Color.LightSeaGreen;
            LabelResult.Text = "Successfully insert artist";
            TextBoxArtistName.Text = "";
        }
    }
}