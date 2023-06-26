using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("userG")]
    public class UserGupoController : Controller
    {
        //metodo para crear una relacion de amistad 
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.UsuarioGrupo modelo)
        {

            var res = await DataBase.UsurioGrupoDB.Create(modelo);
            return res;

        }

        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int IdGrupos)
        {

            var res = await DataBase.UsurioGrupoDB.Listar(IdGrupos);
            return res;

        }

        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {

            var res = await DataBase.UsurioGrupoDB.Delete(id);
            return res;

        }
    }
}
