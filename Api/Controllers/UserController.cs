using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("User")]
    public class UserController : ControllerBase
    {
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id )
        {

            var res = await DataBase.UserDB.Listar(id);
            return res;

        }

        [HttpPost("Update")]
        public async Task<dynamic> Post([FromBody] Models.Usuario modelo,[FromQuery] int id)
        {

            var res = await DataBase.UserDB.Update(modelo,id);
            return res;

        }

        [HttpPut("Create")]
        public async Task<dynamic> Put([FromBody] Models.Usuario modelo)
        {

            var res = await DataBase.UserDB.Create(modelo);
            return res;

        }

        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {

            var res = await DataBase.UserDB.Delete(id);
            return res;

        }

    }

}
