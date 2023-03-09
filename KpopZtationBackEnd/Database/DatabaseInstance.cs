using KpopZtationBackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZtationBackEnd.Database
{
    public class DatabaseInstance
    {
        private static DatabaseEntities Db;

        private DatabaseInstance()
        {
            
        }

        public static DatabaseEntities GetDb()
        {
            if (Db == null)
            {
                Db = new DatabaseEntities();
            }
            return Db;
        }
    }
}