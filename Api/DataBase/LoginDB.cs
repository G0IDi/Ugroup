using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class LoginDB
    {
        public static async Task<bool> Registro(Models.LogIn modelo)
        {
            string query = "SELECT COUNT(*) FROM USUARIO WHERE CORREO = @Email AND CONTRASEÑA = @Contrasena";

            try
            {
                using (MySqlConnection connection = Conexion.GetOneConnection().DataBase)
                {
                    using (MySqlCommand comando = new MySqlCommand(query, connection))
                    {
                        comando.Parameters.AddWithValue("@Email", modelo.Email);
                        comando.Parameters.AddWithValue("@Contrasena", modelo.Contrasena);

                        int rowCount = Convert.ToInt32(await comando.ExecuteScalarAsync());
                        return rowCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }
    }
}
