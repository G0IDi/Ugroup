using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // Método HTTP POST realizar un log in
    [Route("LogIn")]
    public class LoginController : Controller
    {
        [HttpPost("Confirmacion")]
        public async Task<IActionResult> Post([FromBody] LogIn modeloLogin)
        {
            try
            {
                int resultado = await DataBase.LoginDB.Registro(modeloLogin); // Llama al método Registro de la clase LoginDB para realizar la confirmación del inicio de sesión
                if (resultado > 0)
                    return Ok(resultado); // Devuelve un resultado exitoso (código 200) con el resultado obtenido

                return StatusCode(401); // Devuelve un código de estado 401 (No autorizado) si la confirmación del inicio de sesión falla
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Devuelve un código de estado 500 (Error interno del servidor) junto con el mensaje de error en caso de una excepción
            }
        }
    }
}
