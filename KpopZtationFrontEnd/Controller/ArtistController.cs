using KpopZtationFrontEnd.Model;
using KpopZtationFrontEnd.Service;
using KpopZtationFrontEnd.WebServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

            return response.Content.Select(artist =>
            {
                artist.ArtistImage = "~/Assets/Artists/" + artist.ArtistImage;
                return artist;
            }).ToList();
        }
    }
}