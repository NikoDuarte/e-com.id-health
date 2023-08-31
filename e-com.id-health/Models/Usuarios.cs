using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace e_com.id_health.Models
{
    public class Usuarios
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
