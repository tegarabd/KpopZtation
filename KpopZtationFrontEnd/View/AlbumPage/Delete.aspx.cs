using KpopZtationFrontEnd.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.View.AlbumPage
{
    public partial class Delete : System.Web.UI.Page
    {
        private readonly AlbumController albumController = AlbumController.GetInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString.Get("id"));
            int artistId = Convert.ToInt32(Request.QueryString.Get("artistId"));
            albumController.DeleteAlbum(this, artistId, id);
        }
    }
}