using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.ArtistPage
{
    public partial class Detail : System.Web.UI.Page
    {
        private readonly ArtistController artistController = ArtistController.GetInstance();
        public Artist Artist;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            Artist = artistController.GetArtistById(id);
        }
    }
}