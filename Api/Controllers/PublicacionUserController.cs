using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Publicacion")]
    public class PublicacionUserController : ControllerBase
    {

        //metodo para crear una relacion de amistad 
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.PublicacionesUsuario modelo)
        {

            var res = await DataBase.PublicacionUserDB.Create(modelo);
            return res;

        }

        // metodo para actualizar la info 
        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.PublicacionesUsuario modelo, [FromQuery] int id)
        {

            var res = await DataBase.PublicacionUserDB.Update(modelo, id);
            return res;

        }

        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int IdGrupos)
        {

            var res = await DataBase.PublicacionUserDB.Listar(IdGrupos);
            return res;

        }

        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {

            var res = await DataBase.PublicacionUserDB.Delete(id);
            return res;

        }
    }
}
