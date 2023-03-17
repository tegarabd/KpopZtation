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

        public Artist GetArtistById(int id)
        {
            return artistRepository.GetArtistById(id);
        }

        public Artist InsertArtist(string name, string image)
        {
            Artist artistRegisteredName = artistRepository.GetArtistByName(name);
            if (artistRegisteredName != null)
            {
                throw new Exception("Name already used");
            }
            Artist artist = artistFactory.Create(name, image);
            artistRepository.InsertArtist(artist);
            return artist;
        }

        public Artist UpdateArtist(int id, string name, string image)
        {
            Artist artistRegisteredName = artistRepository.GetArtistByName(name);
            if (artistRegisteredName != null)
            {
                throw new Exception("Name already used");
            }

            Artist artist = new Artist() { 
                ArtistID = id,
                ArtistName = name,
                ArtistImage = image
            };

            artistRepository.UpdateArtist(artist);

            return artist;
        }

        public Artist DeleteArtist(int id)
        {
            Artist artist = artistRepository.GetArtistById(id);
            if (artist == null)
            {
                throw new Exception("Artist not found");
            }

            artistRepository.DeleteArtist(artist);
            return artist;
        }
    }
}