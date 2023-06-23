using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Net;

namespace Api.DataBase
{
    public class LoginDB
    {
        public static async Task<int> Registro(Models.LogIn modelo)
        {
            string query = "SELECT ID FROM USUARIO WHERE CORREO = @Email AND CONTRASEÑA = @Contrasena";

            try
            {
                using (MySqlConnection connection = Conexion.GetOneConnection().DataBase)
                {
                    using (MySqlCommand comando = new MySqlCommand(query, connection))
                    {
                        comando.Parameters.AddWithValue("@Email", modelo.Email);
                        comando.Parameters.AddWithValue("@Contrasena", modelo.Contrasena);

                        int id = Convert.ToInt32(await comando.ExecuteScalarAsync());
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }


        }
    }
}
