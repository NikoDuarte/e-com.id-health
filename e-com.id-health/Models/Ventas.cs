using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace e_com.id_health.Models
{
    public class Ventas
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public List<string> ids_productos { get; set; }
        public string name_client { get; set; }
        public string address_client { get; set; }
        public string phone_client { get; set; }
        public string guia_envio { get; set; }
        public int total_price { get; set; }
    }
}
