using e_com.id_health.Models;

namespace e_com.id_health.Database.Collection.Usuario
{
    public interface IUsuarioCollection
    {
        Task InsertUser(Usuarios user);

        Task<Usuarios> GetUserEmail(string email);
    }
}
