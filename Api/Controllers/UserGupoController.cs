using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("userG")]
    public class UserGupoController : Controller
    {
        // Método HTTP POST para crear una relación de amistad entre usuarios y grupos
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.UsuarioGrupo modelo)
        {
            var res = await DataBase.UsurioGrupoDB.Create(modelo); // Llama al método Create de la clase UsurioGrupoDB para crear la relación
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP GET para obtener los grupos a los que pertenece un usuario
        [HttpGet("ListGrupos")]
        public async Task<dynamic> GetGrupos([FromQuery] int IdGrupos)
        {
            var res = await DataBase.UsurioGrupoDB.ListarGrupos(IdGrupos); // Llama al método ListarGrupos de la clase UsurioGrupoDB para obtener los grupos
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP GET para obtener los usuarios que pertenecen a un grupo
        [HttpGet("ListUsuario")]
        public async Task<dynamic> GetUsuario([FromQuery] int IdGrupos)
        {
            var res = await DataBase.UsurioGrupoDB.ListarUsuario(IdGrupos); // Llama al método ListarUsuario de la clase UsurioGrupoDB para obtener los usuarios
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP DELETE para eliminar una relación de amistad entre usuarios y grupos
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {
            var res = await DataBase.UsurioGrupoDB.Delete(id); // Llama al método Delete de la clase UsurioGrupoDB para eliminar la relación
            return res; // Devuelve el resultado obtenido
        }
    }
}
