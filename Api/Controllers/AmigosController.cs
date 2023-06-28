namespace Api.Controllers
{
    // Ruta base para las acciones del controlador
    [Route("Amigo")]
    public class AmigosController : ControllerBase
    {
        // Método HTTP GET para obtener todas tus amistades
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id)
        {
            var res = await DataBase.AmigoDB.Listar(id); // Llama al método Listar de la clase AmigoDB para obtener las amistades
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP POST para crear una relación de amistad
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.Amigos modelo)
        {
            var res = await DataBase.AmigoDB.CreateAmistad(modelo); // Llama al método CreateAmistad de la clase AmigoDB para crear la amistad
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP PUT para actualizar una relación de amistad
        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.Amigos modelo, [FromQuery] int id)
        {
            var res = await DataBase.AmigoDB.Update(modelo, id); // Llama al método Update de la clase AmigoDB para actualizar la amistad
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP DELETE para eliminar una relación de amistad
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {
            var res = await DataBase.AmigoDB.Delete(id); // Llama al método Delete de la clase AmigoDB para eliminar la amistad
            return res; // Devuelve el resultado obtenido
        }
    }
}

