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
            
            // Consulta para crear user
            string query = $""" INSERT INTO `USUARIO` (`NOMBRE`, `APELLIDO` ,`CORREO`, `CONTRASEÑA`, `F_NACIMIENTO`)  VALUES ('{modelo.NombreUsuario}','{modelo.Apellido}','{modelo.Email}','{modelo.Contraseña}', '{modelo.Fnacimiento:yyyy-MM-dd}')""";

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

            // Consulta para actualizar la info del user
            string query = $""" UPDATE `USUARIO` SET NOMBRE = '{modelo.NombreUsuario}', APELLIDO = '{modelo.Apellido}', CORREO = '{modelo.Email}', CONTRASEÑA = '{modelo.Contraseña}', F_NACIMIENTO = '{modelo.Fnacimiento:yyyy-MM-dd}' WHERE ID = {id}  """;

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

            // Consulta para traer y listar la info del user
            string query = $"""SELECT * FROM USUARIO WHERE ID = '{id}';""";

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

            // Consulta para eliminar la info del user
            string query = $""" DELETE FROM `USUARIO` WHERE ID = {id}""";

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