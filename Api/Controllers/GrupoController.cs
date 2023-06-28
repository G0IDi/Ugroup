namespace Api.Controllers
{
    // Ruta base para las acciones del controlador
    [Route("Grupo")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        // Método HTTP GET para obtener la información del grupo
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id)
        {
            var res = await DataBase.GrupoDB.Listar(id); // Llama al método Listar de la clase GrupoDB para obtener la información del grupo
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP GET para obtener toda la información del grupo
        [HttpGet("ListTodo")]
        public async Task<dynamic> GetTodo([FromQuery] int id)
        {
            var res = await DataBase.GrupoDB.ListarTodo(id); // Llama al método ListarTodo de la clase GrupoDB para obtener toda la información del grupo
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP POST para crear la información del grupo
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.Grupo modelo)
        {
            var res = await DataBase.GrupoDB.Create(modelo); // Llama al método Create de la clase GrupoDB para crear la información del grupo
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP PUT para actualizar la información del grupo
        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.Grupo modelo, [FromQuery] int id)
        {
            var res = await DataBase.GrupoDB.Update(modelo, id); // Llama al método Update de la clase GrupoDB para actualizar la información del grupo
            return res; // Devuelve el resultado obtenido
        }

        // Método HTTP DELETE para eliminar la información del grupo
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {
            var res = await DataBase.GrupoDB.Delete(id); // Llama al método Delete de la clase GrupoDB para eliminar la información del grupo
            return res; // Devuelve el resultado obtenido
        }
    }
}
