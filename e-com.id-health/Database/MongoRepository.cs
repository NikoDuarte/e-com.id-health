using MongoDB.Driver;

namespace e_com.id_health.Database
{
    public class MongoRepository
    {
        public MongoClient Client;
        public IMongoDatabase Database;

        public MongoRepository()
        {
            Client = new MongoClient("mongodb+srv://cloud_p:La6xA8O1wnzUnctl@pruebas.w2ui7g2.mongodb.net/");
            Database = Client.GetDatabase("ecommers");
        }
    }
}
