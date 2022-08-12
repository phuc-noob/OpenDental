using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Utils
{
   internal class Database
   {
      private static MongoDatabase mongoDatabase;

      public static MongoDatabase MongoDatabase
      {
         get
         {
            if (mongoDatabase == null)
            {
               
               mongoDatabase = new MongoDatabase(
                
               // CONFIG 'Object reference not set to an instance of an object.'
               // GET NULL VALUE 
               Config.Manager.MONGO_DB_HOST,
               Config.Manager.MONGO_DB_PORT,
               Config.Manager.MONGO_DB_USERNAME,
               Config.Manager.MONGO_DB_PASSWORD,
               Config.Manager.MONGO_DB_DATABASE_NAME,
               Config.Manager.MONGO_DB_CACHE
               );
               MongoDatabase.OpenConnection();
            }
            return mongoDatabase;
         }
      }

      

      //public static MongoDatabase MongoDatabase;
      //public static void CreateMongoConnection()
      //{
      //   MongoDatabase = new MongoDatabase(Config.Manager.MONGO_DB_HOST, Config.Manager.MONGO_DB_PORT, Config.Manager.MONGO_DB_DATABASE_NAME, Config.Manager.MONGO_DB_CACHE);
      //   MongoDatabase.OpenConnection();
      //}
      //static Database()
      //{
      //   CreateMongoConnection();
      //}
   }
}
