using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    /// <summary>
    /// Clase encargada de conectar con la base de datos de usuarios.
    /// </summary>
    public class UserDB
    {
        /// <summary>
        /// Crea un usuario en la base de datos.
        /// </summary>
        /// <param name="modelo">Modelo del usuario para crear</param>
        /// <returns>Estado de la operación</returns>
        public static async Task<dynamic> Create(Models.Usuario modelo)
        {
            // Consulta para crear un usuario
            string query = $""" INSERT INTO `USUARIO` (`NOMBRE`, `APELLIDO` ,`CORREO`, `CONTRASEÑA`, `F_NACIMIENTO`)  VALUES ('{modelo.NombreUsuario}','{modelo.Apellido}','{modelo.Email}','{modelo.Contrasena}', '{modelo.Fnacimiento:yyyy-MM-dd}')""";

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID del usuario insertado
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }

        /// <summary>
        /// Actualiza los datos de un usuario en la base de datos.
        /// </summary>
        /// <param name="modelo">Modelo del usuario para actualizar</param>
        /// <param name="id">ID del usuario</param>
        /// <returns>Estado de la operación</returns>
        public static async Task<dynamic> Update(Models.Usuario modelo, int id)
        {
            // Consulta para actualizar la información del usuario
            string query = $""" UPDATE `USUARIO` SET NOMBRE = '{modelo.NombreUsuario}', APELLIDO = '{modelo.Apellido}', CORREO = '{modelo.Email}', CONTRASEÑA = '{modelo.Contrasena}', F_NACIMIENTO = '{modelo.Fnacimiento:yyyy-MM-dd}' WHERE ID = {id}  """;

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID del usuario actualizado
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }

        /// <summary>
        /// Obtiene una lista de usuarios según el ID del usuario.
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns>Lista de usuarios</returns>
        public static async Task<List<Models.Usuario>> Listar(int id)
        {
            // Consulta para traer y listar la información del usuario
            string query = $"""SELECT * FROM USUARIO WHERE ID = '{id}';""";

            // Ejecución
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
                    // Mapeo de los modelos mediante su ubicación en la fila
                    var modelo = new Models.Usuario
                    {
                        ID = reader.GetInt32(0),
                        NombreUsuario = reader.GetString(1),
                        Contrasena = reader.GetString(2),
                        Email = reader.GetString(3)
                    };

                    // Agrega el modelo a la lista
                    usuarios.Add(modelo);
                }

                // Retorna la lista de usuarios
                return usuarios;
            }
            catch
            {
                // -- Manejo de errores
            }

            return new();
        }

        /// <summary>
        /// Elimina un usuario de la base de datos.
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns>Estado de la operación</returns>
        public static async Task<dynamic> Delete(int id)
        {
            // Consulta para eliminar la información del usuario
            string query = $""" DELETE FROM `USUARIO` WHERE ID = {id}""";

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID del usuario eliminado
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
