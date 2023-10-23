using sistemaCrud.interfaces;
using sistemaCrud.Models;
using sistemaCrud.repositories;


namespace sistemaCrud.Services
{
    public class UserService : IUserServiceInterface
    {
        private readonly IUserInterface _userRepository;

        public UserService(IUserInterface userRepository) {
            _userRepository = userRepository;
        }

        public async Task<List<UsuarioModel>> GetAllUsers() {
            return await _userRepository.FindAllUsers();
        }

        public async Task<UsuarioModel> GetById(int id) {
            return await _userRepository.FindById(id);

        }
        public async Task<UsuarioModel> CreateNewUser(UsuarioModel usuario) {
            return await _userRepository.CreateUser(usuario);        
        }

        public async Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id)
        {
         return await _userRepository.UpdateUser(usuario, id); 
        }

        public async Task<bool> DeleteUser(int id)
        {
           return await _userRepository.DeleteUser(id);
        }
    }
}
