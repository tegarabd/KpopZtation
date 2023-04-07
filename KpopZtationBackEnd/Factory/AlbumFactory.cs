using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Factory
{
    public class AlbumFactory
    {
        private static AlbumFactory instance;

        private AlbumFactory()
        {

        }
        public static AlbumFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new AlbumFactory();
            }
            return instance;
        }

        public Album Create(int artistId, string name, string image, string description, int price, int stock)
        {
            return new Album()
            {
                ArtistID = artistId,
                AlbumName = name,
                AlbumImage = image,
                AlbumDescription = description,
                AlbumPrice = price,
                AlbumStock = stock,
            };
        }
        
        public Album Create(string name, string image, string description, int price, int stock, int id)
        {
            return new Album()
            {
                AlbumID = id,
                AlbumName = name,
                AlbumImage = image,
                AlbumDescription = description,
                AlbumPrice = price,
                AlbumStock = stock,
            };
        }
    }
}