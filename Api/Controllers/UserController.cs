using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // Ruta  de lso usuarios
    [Route("User")]
    public class UserController : ControllerBase
    {
        //metodo para listar la info 
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id )
        {

            var res = await DataBase.UserDB.Listar(id);
            return res;

        }
        //metodo para crear la info 
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.Usuario modelo)
        {

            var res = await DataBase.UserDB.Create(modelo);
            return res;

        }

        // metodo para actualizar la info 
        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.Usuario modelo, [FromQuery] int id)
        {

            var res = await DataBase.UserDB.Update(modelo, id);
            return res;

        }
   
        //metodo para eliminar la info 
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {

            var res = await DataBase.UserDB.Delete(id);
            return res;

        }

    }

}
