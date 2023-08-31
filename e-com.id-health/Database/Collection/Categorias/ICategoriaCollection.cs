using e_com.id_health.Models;

namespace e_com.id_health.Database.Collection.Categoria
{
    public interface ICategoriaCollection
    {
        Task<List<Categorias>> GetAllCategorias();
        Task<Categorias> GetCategoriasById(string id);
        Task InsertCategorias(Categorias categoria);
        Task UpdateCategorias(Categorias categoria);
        Task DeleteCategorias(string id);
    }
}
