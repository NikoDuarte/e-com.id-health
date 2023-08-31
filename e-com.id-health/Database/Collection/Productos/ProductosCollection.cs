using e_com.id_health.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace e_com.id_health.Database.Collection.Producto
{
    public class ProductosCollection : IProductosCollection
    {
        internal MongoRepository _repository = new MongoRepository();
        private IMongoCollection<Productos> PCollection;

        public ProductosCollection()
        {
            PCollection = _repository.Database.GetCollection<Productos>("Productos");
        }

        public async Task DeleteProductos(string id)
        {
            var filter = Builders<Productos>.Filter.Eq(obj => obj.Id, new ObjectId(id));
            await PCollection.DeleteOneAsync(filter);
        }

        public async Task<List<Productos>> GetAllProductos()
        {
            return await PCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Productos> GetProductosById(string id)
        {
            return await PCollection
                .FindAsync(
                    new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertProductos(Productos productos)
        {
            await PCollection.InsertOneAsync(productos);
        }

        public async Task UpdateProductos(Productos productos)
        {
            var filter = Builders<Productos>.Filter.Eq(obj => obj.Id, productos.Id);
            if (filter != null)
            {
                await PCollection.ReplaceOneAsync(filter, productos);
            }
        }
    }
}
