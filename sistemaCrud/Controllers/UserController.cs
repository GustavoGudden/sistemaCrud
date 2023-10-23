using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using sistemaCrud.interfaces;
using sistemaCrud.Models;
using sistemaCrud.repositories;
using sistemaCrud.Services;
using System.Diagnostics.Eventing.Reader;

namespace sistemaCrud.Controllers
{
    [Route("api/[controller]")] //isso significa que a rota da api vai ser a porta que vai rodar  /api/user  sendo o user definido pelo nome do controller
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceInterface _userService;
      

        public UserController(IUserServiceInterface userService) {
            _userService = userService;
          
        }

        // Buscar todos 
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsarios() {
            return await _userService.GetAllUsers();
        }


        // Buscar por id 
        [HttpGet("{id}")] 
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id) {
            return await _userService.GetById(id);
        }

        // Criar um novo usuario
        [HttpPost("/create")]
        public async Task<ActionResult<UserModel>> CriarNovoUsuario([FromBody] UsuarioModel usuario)
        {
            await _userService.CreateNewUser(usuario);
            return Ok(usuario);

        }

        // Atualizar um usuario
        [HttpPatch("/update/{id}")]
        public async Task<ActionResult<UserModel>> AtualizarUsuario([FromBody] UsuarioModel usuario,int id) {
        usuario.Id = id;
         await _userService.UpdateUser(usuario, id);
         return Ok(usuario);
                
         }

        // Deletar um usuario
        [HttpDelete("/delete/{id}")]
        public async Task<ActionResult<UserModel>> DeletarUsuario(int id) {

            return Ok(await _userService.DeleteUser(id));
        }
    }
}
