using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace e_com.id_health.Models
{
    public class Categorias
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string id_user { get; set; }
        public string name { get; set; }
        public string desciption { get; set;}
    }
}
