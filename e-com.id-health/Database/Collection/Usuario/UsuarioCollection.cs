using e_com.id_health.Models;
using e_com.id_health.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace e_com.id_health.Database.Collection.Usuario
{
    public class UsuarioCollection : IUsuarioCollection
    {
        internal MongoRepository _repository = new MongoRepository();
        private IMongoCollection<Usuarios> UCollection;

        public UsuarioCollection()
        {
            UCollection = _repository.Database.GetCollection<Usuarios>("Usuarios");
        }

        public async Task InsertUser(Usuarios user)
        {
            await UCollection.InsertOneAsync(user);
        }

        public async Task<Usuarios> GetUserEmail(string email)
        {
            return await UCollection.FindAsync(
                    new BsonDocument { { "email", email } }).Result.FirstAsync();
        }
    }
}
