using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Service;
using KpopZtationFrontEnd.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;

namespace KpopZtationFrontEnd.Controller
{
    public class ArtistController
    {
        private readonly WebService webService;
        private readonly JsonService jsonService;

        private static ArtistController instance;
        private ArtistController()
        {
            webService = WebServiceInstance.GetWebService();
            jsonService = JsonService.GetInstance();
        }

        public static ArtistController GetInstance()
        {
            if (instance == null)
            {
                instance = new ArtistController();
            }
            return instance;
        }

        public List<Artist> GetArtists()
        {
            WebServiceResponse<List<Artist>> response = jsonService
                .Decode<WebServiceResponse<List<Artist>>>(webService.GetArtists());

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }

        public Artist GetArtistById(int id)
        {
            WebServiceResponse<Artist> response = jsonService
                .Decode<WebServiceResponse<Artist>>(webService.GetArtistById(id));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }

        public void InsertArtist(Page page, string name, FileUpload imageFile)
        {
            ValidateInput(name, imageFile);

            WebServiceResponse<Artist> response = jsonService
                .Decode<WebServiceResponse<Artist>>(webService.InsertArtist(name, imageFile.FileName));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            imageFile.SaveAs(page.Server.MapPath("~/Assets/Artists/" + imageFile.FileName));
        }

        public void UpdateArtist(Page page, int id, string name, FileUpload imageFile)
        {
            ValidateInput(name, imageFile);

            WebServiceResponse<Artist> response = jsonService
                .Decode<WebServiceResponse<Artist>>(webService.UpdateArtist(id, name, imageFile.FileName));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            imageFile.SaveAs(page.Server.MapPath("~/Assets/Artists/" + imageFile.FileName));
        }

        public void DeleteArtist(Page page, int id)
        {
            WebServiceResponse<Artist> response = jsonService
                .Decode<WebServiceResponse<Artist>>(webService.DeleteArtist(id));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            page.Response.Redirect("~/View/Home.aspx");
        }

        private void ValidateInput(string name, FileUpload imageFile)
        {
            if (name.Equals(""))
            {
                throw new Exception("Artist Name must be filled");
            }

            if (!imageFile.HasFile)
            {
                throw new Exception("Artist Image must be choosen");
            }

            string fileExtension = Path.GetExtension(imageFile.FileName);
            int fileSize = imageFile.PostedFile.ContentLength;

            if (!(new List<string>() { ".png", ".jpg", ".jpeg", ".jfif" }.Contains(fileExtension)))
            {
                throw new Exception("Artist Image file extension must be .png, .jpg, .jpeg, or .jfif");
            }

            if (fileSize >= 1024 * 1024 * 2)
            {
                throw new Exception("Artist Image file size must be lower than 2MB");
            }
        }
    }
}