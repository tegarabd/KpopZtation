using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View
{
    public partial class Home : System.Web.UI.Page
    {
        private readonly ArtistController artistController = ArtistController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Artist> artists = artistController.GetArtists();
            GridViewArtists.DataSource = artists;
            GridViewArtists.DataBind();
        }

    }
}