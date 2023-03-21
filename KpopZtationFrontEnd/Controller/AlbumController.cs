using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Service;
using KpopZtationFrontEnd.WebServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KpopZtationFrontEnd.Controller
{
    public class AlbumController
    {
        private readonly WebService webService;
        private readonly JsonService jsonService;

        private static AlbumController instance;
        private AlbumController()
        {
            webService = WebServiceInstance.GetWebService();
            jsonService = JsonService.GetInstance();
        }

        public static AlbumController GetInstance()
        {
            if (instance == null)
            {
                instance = new AlbumController();
            }
            return instance;
        }

        public Album GetAlbumById(int id)
        {
            WebServiceResponse<Album> response = jsonService
                .Decode<WebServiceResponse<Album>>(webService.GetAlbumById(id));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            return response.Content;
        }

        public void InsertAlbum(Page page, int artistId, string name, FileUpload imageFile, string description, string price, string stock)
        {
            int priceAsInt, stockAsInt;
            ValidateInput(name, imageFile, description, price, stock, out priceAsInt, out stockAsInt);

            WebServiceResponse<Album> response = jsonService
                .Decode<WebServiceResponse<Album>>(webService.InsertAlbum(artistId, name, imageFile.FileName, description, priceAsInt, stockAsInt));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            imageFile.SaveAs(page.Server.MapPath("~/Assets/Albums/" + imageFile.FileName));
        }

        public void UpdateAlbum(Page page, int id, string name, FileUpload imageFile, string description, string price, string stock)
        {
            int priceAsInt, stockAsInt;
            ValidateInput(name, imageFile, description, price, stock, out priceAsInt, out stockAsInt);

            WebServiceResponse<Album> response = jsonService
                .Decode<WebServiceResponse<Album>>(webService.UpdateAlbum(id, name, imageFile.FileName, description, priceAsInt, stockAsInt));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            imageFile.SaveAs(page.Server.MapPath("~/Assets/Albums/" + imageFile.FileName));
        }

        public void DeleteAlbum(Page page, int artistId, int id)
        {
            WebServiceResponse<Artist> response = jsonService
                .Decode<WebServiceResponse<Artist>>(webService.DeleteAlbum(id));

            if (!response.Ok)
            {
                throw new Exception(response.Message);
            }

            page.Response.Redirect("~/View/ArtistPage/Detail.aspx?id=" + artistId);
        }

        private void ValidateInput(string name, FileUpload imageFile, string description, string price, string stock, out int priceAsInt, out int stockAsInt)
        {
            if (name.Equals(""))
            {
                throw new Exception("Album Name must be filled");
            }

            if (name.Length >= 50)
            {
                throw new Exception("Album Name must be shorter than 50 characters");
            }

            if (description.Equals(""))
            {
                throw new Exception("Album description must be filled");
            }

            if (description.Length >= 255)
            {
                throw new Exception("Album description must be shorter than 255 characters");
            }

            if (price.Equals(""))
            {
                throw new Exception("Album Price must be filled");
            }

            priceAsInt = Convert.ToInt32(price);
            if (priceAsInt < 100000 || priceAsInt > 1000000)
            {
                throw new Exception("Album price must be between 100000 and 1000000");
            }

            if (stock.Equals(""))
            {
                throw new Exception("Album Stock must be filled");
            }

            stockAsInt = Convert.ToInt32(stock);
            if (stockAsInt <= 0)
            {
                throw new Exception("Album stock must be more than 0");
            }

            if (!imageFile.HasFile)
            {
                throw new Exception("Album Image must be choosen");
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