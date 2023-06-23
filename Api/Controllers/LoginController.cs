using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("LogIn")]
    public class LoginController : Controller
    {
        [HttpPost("Confirmacion")]
        public async Task<IActionResult> Post([FromBody] LogIn modeloLogin)
        {
            try
            {
                int resultado = await DataBase.LoginDB.Registro(modeloLogin);
                if (resultado > 0)

                    return Ok(resultado);


                return StatusCode(401);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
