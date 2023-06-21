using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Api.Controllers
{
    [Route("LogIn")]
    public class LoginController : Controller
    {
        [HttpPost("Login")]
        public async Task<dynamic> Post([FromBody] Models.LogIn modeloLogin)
        {
            try
            {
                bool resultado = await DataBase.LoginDB.Registro(modeloLogin);
                return resultado;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
