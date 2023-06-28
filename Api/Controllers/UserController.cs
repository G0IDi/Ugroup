using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("User")]
    public class UserController : ControllerBase
    {
        // Método HTTP GET para obtener la información de un usuario
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id)
        {
            var res = await DataBase.UserDB.Listar(id); // Llama al método Listar de la clase UserDB para obtener la información de un usuario
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP POST para crear la información de un usuario
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.Usuario modelo)
        {
            var res = await DataBase.UserDB.Create(modelo); // Llama al método Create de la clase UserDB para crear la información de un usuario
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP PUT para actualizar la información de un usuario
        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.Usuario modelo, [FromQuery] int id)
        {
            var res = await DataBase.UserDB.Update(modelo, id); // Llama al método Update de la clase UserDB para actualizar la información de un usuario
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP DELETE para eliminar la información de un usuario
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {
            var res = await DataBase.UserDB.Delete(id); // Llama al método Delete de la clase UserDB para eliminar la información de un usuario
            return res; // Devuelve el resultado obtenido
        }
    }
}
