using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Net;

namespace Api.DataBase
{
    public class LoginDB
    {
        public static async Task<int> Registro(Models.LogIn modelo)
        {
            // Consulta para buscar un usuario en la base de datos
            string query = "SELECT ID FROM USUARIO WHERE CORREO = @Email AND CONTRASEÑA = @Contrasena";

            try
            {
                // Se establece la conexión a la base de datos y se utiliza el bloque 'using' para asegurar que la conexión se cierre correctamente
                using (MySqlConnection connection = Conexion.GetOneConnection().DataBase)
                {
                    // Se crea el comando con la consulta y la conexión
                    using (MySqlCommand comando = new MySqlCommand(query, connection))
                    {
                        // Se asignan los valores de los parámetros utilizando propiedades del modelo
                        comando.Parameters.AddWithValue("@Email", modelo.Email);
                        comando.Parameters.AddWithValue("@Contrasena", modelo.Contrasena);

                        // Se ejecuta la consulta y se obtiene el valor de la primera columna de la primera fila del resultado
                        int id = Convert.ToInt32(await comando.ExecuteScalarAsync());

                        // Se devuelve el ID obtenido
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de excepción, se muestra el mensaje de error en la consola y se devuelve un valor predeterminado (0 en este caso)
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
