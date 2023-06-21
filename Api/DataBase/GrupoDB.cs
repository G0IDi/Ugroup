using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;


namespace Api.DataBase
{
    public class GrupoDB
    {

        /// <summary>
        /// Crea un usuario en la base de datos
        /// </summary>
        /// <param name="modelo">Modelo del usuario para crear</param>
        public static async Task<dynamic> Create(Models.Grupo modelo)
        {

            // Consulta para crear user
            string query = $""" INSERT INTO `GRUPOS` (`NOMBRE_GRUPO`, `DESCRIPCION`, `ID_TEMAS`  )  VALUES ('{modelo.Name}','{modelo.Description}', '{modelo.IdTemas}')""";

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
        public static async Task<dynamic> Update(Models.Grupo modelo, int id)
        {

            // Consulta para actualizar la info del user
            string query = $""" UPDATE `GRUPOS` SET NOMBRE_GRUPO = '{modelo.Name}', DESCRIPCION = '{modelo.Description}' WHERE ID = {id}  """;

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




        public static async Task<List<Models.Grupo>> Listar(int id)
        {

            // Consulta para traer y listar la info del user
            string query = $"""SELECT * FROM GRUPOS WHERE ID = '{id}';""";

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
                List<Models.Grupo> grupos = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicacion en la fila
                    var modelo = new Models.Grupo
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),  
                    };

                    // Agrega el modelo a la lista
                    grupos.Add(modelo);
                }

                // Retorna la lista
                return grupos;

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
            string query = $""" DELETE FROM `GRUPOS` WHERE ID = {id}""";

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
