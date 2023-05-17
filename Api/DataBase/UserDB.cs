using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Api.DataBase
{

    /// <summary>
    /// Clase encargada de conectar con la base de datos
    /// </summary>
    public class UserDB
    {




        /// <summary>
        /// Crea un usuario en la base de datos
        /// </summary>
        /// <param name="modelo">Modelo del usuario para crear</param>
        public static async Task<dynamic> Create(Models.Usuario modelo)
        {

            // Consulta
            string query = $""" INSERT INTO `usuarios`(`NOMBRE`, `EMAIL`, `CONTRASENA`)  VALUES ('{modelo.NombreUsuario}','{modelo.Email}','{modelo.Contraseña}')""";

            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID del insertado
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return "OK";

        }


        /// <summary>
        /// Actualiza undato de la base de datos
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns></returns>
        public static async Task<dynamic> Update(Models.Usuario modelo, int id)
        {

            // Consulta
            string query = $""" UPDATE `usuarios` SET NOMBRE = '{modelo.NombreUsuario}', EMAIL = '{modelo.Email}', CONTRASENA = '{modelo.Contraseña}' WHERE ID = {id}  """;

            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID del insertado
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return "OK";

        }




        public static async Task<List<Models.Usuario>> Listar(int id)
        {

            // Consulta
            string query = $"""SELECT * FROM usuarios WHERE id = '{id}';""";

            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // Ejecuta un reader sobre la consulta
                var reader = comando.ExecuteReader();

                // Pregunta si no hay registros
                if (!reader.HasRows)
                {
                    reader.Close();
                    return new();
                }

                // Lista de usuarios
                List<Models.Usuario> usuarios = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicacion en la fila
                    var modelo = new Models.Usuario
                    {
                        ID = reader.GetInt32(0),
                        NombreUsuario = reader.GetString(1),
                        Contraseña = reader.GetString(2),
                        Email = reader.GetString(3)
                    };

                    // Agrega el modelo a la lista
                    usuarios.Add(modelo);
                }

                // Retorna la lista
                return usuarios;

            }
            catch
            {
                // -- Manejor de errores
            }


            return new();

        }



        /// <summary>
        /// Elimina un usuario de la base de datos
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns></returns>
        public static async Task<dynamic> Delete(int id)
        {

            // Consulta
            string query = $""" DELETE FROM `USUARIOS` WHERE ID = {id}""";

            // Ejecucion
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID del insertado
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return "OK";

        }


    }
}