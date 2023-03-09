using KpopZtationBackEnd.Database;
using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Repository
{
    public class AlbumRepository
    {
        private readonly DatabaseEntities Db;
        private static AlbumRepository instance;

        private AlbumRepository()
        {
            Db = DatabaseInstance.GetDb();
        }
        public static AlbumRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AlbumRepository();
            }
            return instance;
        }

        public List<Album> GetAlbums()
        {
            return Db.Albums.ToList();
        }

        public Album GetAlbumById(int id)
        {
            return Db.Albums.Where(album => album.AlbumID == id).FirstOrDefault();
        }

        public void InsertAlbum(Album album)
        {
            Db.Albums.Add(album);
            Db.SaveChanges();
        }

        public void UpdateAlbum(Album album)
        {
            Album toBeUpdatedAlbum = GetAlbumById(album.AlbumID);
            toBeUpdatedAlbum.AlbumDescription = album.AlbumDescription;
            toBeUpdatedAlbum.AlbumImage = album.AlbumImage;
            toBeUpdatedAlbum.AlbumName = album.AlbumName;
            toBeUpdatedAlbum.AlbumPrice = album.AlbumPrice;
            toBeUpdatedAlbum.AlbumStock = album.AlbumStock;
            toBeUpdatedAlbum.ArtistID = album.ArtistID;
            Db.SaveChanges();
        }

        public void DeleteAlbum(Album album)
        {
            Db.Albums.Remove(album);
            Db.SaveChanges();
        }
    }
}