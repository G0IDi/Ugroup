using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Publicacion")]
    public class PublicacionUserController : ControllerBase
    {
        // Método HTTP POST para crear una publicación de usuario
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.PublicacionesUsuario modelo)
        {
            var res = await DataBase.PublicacionUserDB.Create(modelo); // Llama al método Create de la clase PublicacionUserDB para crear una publicación de usuario
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP PUT para actualizar una publicación de usuario
        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.PublicacionesUsuario modelo, [FromQuery] int id)
        {
            var res = await DataBase.PublicacionUserDB.Update(modelo, id); // Llama al método Update de la clase PublicacionUserDB para actualizar una publicación de usuario
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP GET para obtener las publicaciones de un grupo
        [HttpGet("List")]
        public async Task<dynamic> Get()
        {
            var res = await DataBase.PublicacionUserDB.Listar(); // Llama al método Listar de la clase PublicacionUserDB para obtener las publicaciones de un grupo
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP DELETE para eliminar una publicación de usuario
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {
            var res = await DataBase.PublicacionUserDB.Delete(id); // Llama al método Delete de la clase PublicacionUserDB para eliminar una publicación de usuario
            return res; // Devuelve el resultado obtenido
        }
    }
}
