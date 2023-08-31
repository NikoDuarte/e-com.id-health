using e_com.id_health.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace e_com.id_health.Database.Collection.Tienda
{
    public class TiendasCollection : ITiendasCollection
    {
        internal MongoRepository _repository = new MongoRepository();
        private IMongoCollection<Tiendas> TCollection;

        public TiendasCollection()
        {
            TCollection = _repository.Database.GetCollection<Tiendas>("Tiendas");
        }

        public async Task DeleteTienda(string id)
        {
            var filter = Builders<Tiendas>.Filter.Eq(obj => obj.Id, new ObjectId(id));
            await TCollection.DeleteOneAsync(filter);
        }

        public async Task<List<Tiendas>> GetAllTiendas()
        {
            return await TCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Tiendas> GetTiendasById(string id)
        {
            return await TCollection.FindAsync(
                    new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertTienda(Tiendas tienda)
        {
            await TCollection.InsertOneAsync(tienda);
        }

        public async Task UpdateTienda(Tiendas tienda)
        {
            var filter = Builders<Tiendas>.Filter.Eq(obj => obj.Id, tienda.Id);
            if (filter != null)
            {
                await TCollection.ReplaceOneAsync(filter, tienda);
            }

        }
    }
}
