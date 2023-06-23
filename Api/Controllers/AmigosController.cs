namespace Api.Controllers
{

    [Route("Amigo")]
    public class AmigosController : ControllerBase
    {
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id)
        {

            var res = await DataBase.AmigoDB.Listar(id);
            return res;

        }

        //metodo para crear la info 
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.Amigos modelo)
        {

            var res = await DataBase.AmigoDB.CreateAmistad(modelo);
            return res;

        }

        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {

            var res = await DataBase.AmigoDB.Delete(id);
            return res;

        }
    }
}

