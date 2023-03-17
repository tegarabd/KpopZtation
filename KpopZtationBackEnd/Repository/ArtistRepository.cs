using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using KpopZtationBackEnd.Database;
using KpopZtationBackEnd.Model;

namespace KpopZtationBackEnd.Repository
{
    public class ArtistRepository
    {
        private readonly DatabaseEntities Db;
        private static ArtistRepository instance;

        private ArtistRepository()
        {
            Db = DatabaseInstance.GetDb();
        }

        public static ArtistRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ArtistRepository();
            }
            return instance;
        }

        public List<Artist> GetArtists()
        {
            return Db.Artists.ToList();
        }

        public Artist GetArtistById(int id)
        {
            return Db.Artists.Where(artist => artist.ArtistID == id).FirstOrDefault();
        }

        public Artist GetArtistByName(string name)
        {
            return Db.Artists.Where(artist => artist.ArtistName == name).FirstOrDefault();
        }

        public void InsertArtist(Artist artist)
        {
            Db.Artists.Add(artist);
            Db.SaveChanges();
        }

        public void UpdateArtist(Artist artist)
        {
            Artist toBeUpdatedArtist = GetArtistById(artist.ArtistID);
            toBeUpdatedArtist.ArtistImage = artist.ArtistImage;
            toBeUpdatedArtist.ArtistName = artist.ArtistName;
            Db.SaveChanges();
        }

        public void DeleteArtist(Artist artist)
        {
            Db.Albums.RemoveRange(artist.Albums);
            Db.Artists.Remove(artist);
            Db.SaveChanges();
        }
    }
}