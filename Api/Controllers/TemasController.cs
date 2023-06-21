using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Temas")]
    [ApiController]
    public class TemasController : ControllerBase
    {

        //metodo para listar la info 
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int IdTema)
        {

            var res = await DataBase.TemasDB.Listar(IdTema);
            return res;

        }
    }
}
