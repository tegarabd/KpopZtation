using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Factory
{
    public class ArtistFactory
    {
        private static ArtistFactory instance;

        private ArtistFactory()
        {

        }
        public static ArtistFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new ArtistFactory();
            }
            return instance;
        }
        public Artist Create(string name, string image)
        {
            return new Artist() { 
                ArtistName = name,
                ArtistImage = image,
            };

        }
        public Artist Create(int id, string name, string image)
        {
            return new Artist() { 
                ArtistID = id,
                ArtistName = name,
                ArtistImage = image,
            };

        }

       
    }
}