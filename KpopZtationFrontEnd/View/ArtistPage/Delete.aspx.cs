using KpopZtationFrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.ArtistPage
{
    public partial class Delete : System.Web.UI.Page
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

            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            artistController.DeleteArtist(this, id);
        }
    }
}