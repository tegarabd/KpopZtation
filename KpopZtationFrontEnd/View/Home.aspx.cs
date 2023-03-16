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
        public AuthenticationController authenticationController = AuthenticationController.GetInstance();
        private readonly ArtistController artistController = ArtistController.GetInstance();
        public List<Artist> artists = new List<Artist>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            artists = artistController.GetArtists();
        }

        protected void ButtonInsertArtist_Click(object sender, EventArgs e)
        {

        }
    }
}