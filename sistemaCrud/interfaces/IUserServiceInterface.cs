using sistemaCrud.Models;
using sistemaCrud.repositories;

namespace sistemaCrud.interfaces
{
    public interface IUserServiceInterface
    {
        public Task<List<UsuarioModel>> GetAllUsers();
        public Task<UsuarioModel> GetById(int id);
        public Task<UsuarioModel> CreateNewUser(UsuarioModel usuario);
        public Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id);
        public Task<bool> DeleteUser(int id);


    }
}

