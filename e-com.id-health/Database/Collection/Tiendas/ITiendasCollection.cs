using e_com.id_health.Models;

namespace e_com.id_health.Database.Collection.Tienda
{
    public interface ITiendasCollection
    {
        Task<List<Tiendas>> GetAllTiendas();
        Task<Tiendas> GetTiendasById(string id);
        Task InsertTienda(Tiendas tienda);
        Task UpdateTienda(Tiendas tienda);
        Task DeleteTienda(string id);
    }
}
