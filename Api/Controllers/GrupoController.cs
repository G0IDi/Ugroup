using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Grupo")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        //metodo para listar la info 
        [HttpGet("List")]
        public async Task<dynamic> Get([FromQuery] int id)
        {

            var res = await DataBase.GrupoDB.Listar(id);
            return res;

        }

        //metodo para listar la info 
        [HttpGet("ListTodo")]
        public async Task<dynamic> GetTodo([FromQuery] int id)
        {

            var res = await DataBase.GrupoDB.ListarTodo(id);
            return res;

        }
        //metodo para crear la info 
        [HttpPost("Create")]
        public async Task<dynamic> Post([FromBody] Models.Grupo modelo)
        {

            var res = await DataBase.GrupoDB.Create(modelo);
            return res;

        }

        // metodo para actualizar la info 
        [HttpPut("Update")]
        public async Task<dynamic> Put([FromBody] Models.Grupo modelo, [FromQuery] int id)
        {

            var res = await DataBase.GrupoDB.Update(modelo, id);
            return res;

        }

        //metodo para eliminar la info 
        [HttpDelete("Delete")]
        public async Task<dynamic> Delete([FromQuery] int id)
        {

            var res = await DataBase.GrupoDB.Delete(id);
            return res;

        }
    }
}
