using KpopZtationFrontEnd.Controller;
using KpopZtationFrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.AlbumPage
{
    public partial class Detail : System.Web.UI.Page
    {
        private AlbumController albumController = AlbumController.GetInstance();
        public AuthenticationController authenticationController = AuthenticationController.GetInstance();
        public Album album;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            album = albumController.GetAlbumById(id);
        }
    }
}