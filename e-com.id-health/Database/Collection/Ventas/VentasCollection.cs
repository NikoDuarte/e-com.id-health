using e_com.id_health.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace e_com.id_health.Database.Collection.Venta
{
    public class VentasCollection : IVentasCollection
    {
        internal MongoRepository _repository = new MongoRepository();
        private IMongoCollection<Ventas> VCollection;

        public VentasCollection()
        {
            VCollection = _repository.Database.GetCollection<Ventas>("Ventas");
        }

        public async Task DeleteVentas(string id)
        {
            var filter = Builders<Ventas>.Filter.Eq(obj => obj.Id, new ObjectId(id));
            await VCollection.DeleteOneAsync(filter);
        }

        public async Task<List<Ventas>> GetAllVentas()
        {
            return await VCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Ventas> GetVentasById(string id)
        {
            return await VCollection.FindAsync(
                    new BsonDocument{ { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertVentas(Ventas ventas)
        {
            await VCollection.InsertOneAsync(ventas);
        }

        public async Task UpdateVentas(Ventas ventas)
        {

            var filter = Builders<Ventas>.Filter.Eq(obj => obj.Id, ventas.Id);
            if (filter != null) { 
                await VCollection.ReplaceOneAsync(filter, ventas);  
            }
        }
    }
}
