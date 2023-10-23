using sistemaCrud.Models;
using Microsoft.EntityFrameworkCore;
using sistemaCrud.Data;
using sistemaCrud.interfaces;

namespace sistemaCrud.repositories
{
    public class UserRepository : IUserInterface
    {
        private readonly SistemaTarefasDBContext _dbContext;
   
        public UserRepository(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }

        public async Task<UsuarioModel> FindById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

        }


        public async Task<List<UsuarioModel>> FindAllUsers()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }


        public async Task<UsuarioModel> CreateUser(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
           await  _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id)
        {
            UsuarioModel userToUpdate = await FindById(id) ?? throw new Exception($"Usuario do Id:{id} nao foi encontrado");

            userToUpdate.Nome = usuario.Nome;
            userToUpdate.Email = usuario.Email;
            _dbContext.Usuarios.Update(userToUpdate);
             await _dbContext.SaveChangesAsync();
             return userToUpdate;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UsuarioModel usuarioPorId = await FindById(id) ?? throw new Exception($"Usuario do Id:{id} nao foi encontrado");

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
