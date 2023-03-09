using KpopZtationBackEnd.Factory;
using KpopZtationBackEnd.Model;
using KpopZtationBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Handler
{
    public class ArtistHandler
    {
        private readonly ArtistRepository artistRepository = ArtistRepository.GetInstance();
        private readonly ArtistFactory artistFactory = ArtistFactory.GetInstance();

        public List<Artist> GetArtists()
        {
            return artistRepository.GetArtists();
        }

        public void InsertArtist(string name, string image)
        {
            Artist artistRegisteredName = artistRepository.GetArtistByName(name);
            if (artistRegisteredName != null)
            {
                throw new Exception("Name already used");
            }
            Artist artist = artistFactory.Create(name, image);
            artistRepository.InsertArtist(artist);
        }
    }
}