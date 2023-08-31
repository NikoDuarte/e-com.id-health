using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace e_com.id_health.Models
{
    public class Productos
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string id_tienda { get; set; }
        public string id_categoria { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
    }
}
