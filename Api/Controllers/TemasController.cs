using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Temas")]
    [ApiController]
    public class TemasController : ControllerBase
    {
        // Método HTTP GET para obtener la información de un tema
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int IdTema)
        {
            var res = await DataBase.TemasDB.Listar(IdTema); // Llama al método Listar de la clase TemasDB para obtener la información de un tema
            return res; // Devuelve el resultado obtenido
        }
    }
}
