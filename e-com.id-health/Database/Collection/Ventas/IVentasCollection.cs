using e_com.id_health.Models;

namespace e_com.id_health.Database.Collection.Venta
{
    public interface IVentasCollection
    {
        Task<List<Ventas>> GetAllVentas();
        Task<Ventas> GetVentasById(string id);
        Task InsertVentas(Ventas ventas);
        Task UpdateVentas(Ventas ventas);
        Task DeleteVentas(string id);

    }
}
