using e_com.id_health.Models;

namespace e_com.id_health.Database.Collection.Producto
{
    public interface IProductosCollection
    {
        Task<List<Productos>> GetAllProductos();
        Task<Productos> GetProductosById(string id);
        Task InsertProductos(Productos productos);
        Task UpdateProductos(Productos productos);
        Task DeleteProductos(string id);
    }
}
