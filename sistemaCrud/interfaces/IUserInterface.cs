using sistemaCrud.Models;

namespace sistemaCrud.interfaces
{
    public interface IUserInterface
    {
        Task<List<UsuarioModel>> FindAllUsers();

        Task<UsuarioModel> FindById(int id);

        Task<UsuarioModel> CreateUser(UsuarioModel usuario);

        Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id);

        Task<bool> DeleteUser(int id);

    }
}
