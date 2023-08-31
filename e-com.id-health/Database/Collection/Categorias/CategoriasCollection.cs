using e_com.id_health.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace e_com.id_health.Database.Collection.Categoria
{
    public class CategoriasCollection : ICategoriaCollection
    {
        internal MongoRepository _repository = new MongoRepository();
        private IMongoCollection<Categorias> CCollection;

        public CategoriasCollection()
        {
            CCollection = _repository.Database.GetCollection<Categorias>("Categorias");
        }

        public async Task DeleteCategorias(string id)
        {
            var filter = Builders<Categorias>.Filter.Eq(obj => obj.Id, new ObjectId(id));
            await CCollection.DeleteOneAsync(filter);
        }

        public async Task<List<Categorias>> GetAllCategorias()
        {
            return await CCollection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Categorias> GetCategoriasById(string id)
        {
            return await CCollection.FindAsync(
                    new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertCategorias(Categorias categoria)
        {
            await CCollection.InsertOneAsync(categoria);
        }

        public async Task UpdateCategorias(Categorias categoria)
        {
            var filter = Builders<Categorias>.Filter.Eq(obj => obj.Id, categoria.Id);
            if (filter != null)
            {
                await CCollection.ReplaceOneAsync(filter, categoria);
            }
        }
    }
}
