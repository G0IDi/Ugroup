namespace Api.Controllers
{

    [Route("Amigo")]
    public class AmigosController : ControllerBase
    {
        //metodo para mostrar todas tus amistades
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id)
        {

            var res = await DataBase.AmigoDB.Listar(id);
            return res;

        }

        //metodo para crear una relacion de amistad 
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.Amigos modelo)
        {

            var res = await DataBase.AmigoDB.CreateAmistad(modelo);
            return res;

        }

        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.Amigos modelo, [FromQuery] int id)
        {

            var res = await DataBase.AmigoDB.Update(modelo, id);
            return res;

        }

        //metodo para eliminar una relacion de amistad 
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {

            var res = await DataBase.AmigoDB.Delete(id);
            return res;

        }
    }
}

