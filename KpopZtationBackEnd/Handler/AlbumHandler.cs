using KpopZtationBackEnd.Factory;
using KpopZtationBackEnd.Model;
using KpopZtationBackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Handler
{
    public class AlbumHandler
    {
        private readonly AlbumRepository albumRepository = AlbumRepository.GetInstance();
        private readonly AlbumFactory albumFactory = AlbumFactory.GetInstance();

        public Album InsertAlbum(int artistId, string name, string image, string description, int price, int stock)
        {
            Album album = albumFactory.Create(artistId, name, image, description, price, stock);
            albumRepository.InsertAlbum(album);
            return album;
        }

        public Album GetAlbumById(int id)
        {
            return albumRepository.GetAlbumById(id);
        }
    }
}