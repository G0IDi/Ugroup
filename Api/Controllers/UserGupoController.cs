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

        [HttpGet("ListGrupos")]
        public async Task<dynamic> GetGrupos([FromQuery] int IdGrupos)
        {

            var res = await DataBase.UsurioGrupoDB.ListarGrupos(IdGrupos);
            return res;

        }

        [HttpGet("ListUsuario")]
        public async Task<dynamic> GetUsuario([FromQuery] int IdGrupos)
        {

            var res = await DataBase.UsurioGrupoDB.ListarUsuario(IdGrupos);
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
