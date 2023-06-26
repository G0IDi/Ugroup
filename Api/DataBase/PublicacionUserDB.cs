using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class PublicacionUserDB
    {


        /// <summary>
        /// Crea un usuario en la base de datos
        /// </summary>
        /// <param name="modelo">Modelo del usuario para crear</param>
        public static async Task<dynamic> Create(Models.PublicacionesUsuario modelo)
        {

            // Consulta para crear user 
            string query = $""" INSERT INTO `PUBLICACION_USUARIO`(`ID`, `COMENTARIOS`, `ID_AMIGOS`, `ID_USUARIO`, `DESCRIPCION`, `IMAGEN_PUBLICACION`, `TITULO_PUBLICACION`) VALUES ('{modelo.Id}','{modelo.Comentario}','{modelo.IdAmigos}','{modelo.IdUsuario}', '{modelo.Descripcion}', '{modelo.ImagenPublicacion}', '{modelo.TituloPublicacion}')""";

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
        public static async Task<dynamic> Update(Models.PublicacionesUsuario modelo, int id)
        {

            // Consulta para actualizar la info del user
            string query = $""" UPDATE `PUBLICACION_USUARIO` SET COMENTARIOS = '{modelo.Comentario}', DESCRIPCION  = '{modelo.Descripcion}', IMAGEN_PUBLICACION = '{modelo.ImagenPublicacion}', TITULO_PUBLICACION = '{modelo.TituloPublicacion}' WHERE ID = {id}  """;

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

        public static async Task<List<Models.PublicacionesUsuario>> Listar(int id)
        {

            // Consulta para traer y listar la info del user
            string query = $"""SELECT * FROM PUBLICACION_USUARIO WHERE ID = '{id}';""";

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
                List<Models.PublicacionesUsuario> Publicaciones = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicacion en la fila
                    var modelo = new Models.PublicacionesUsuario
                    {
                        Id = reader.GetInt32(0),
                        Comentario = reader.GetString(1),
                        IdAmigos = reader.GetInt32(2),
                        IdUsuario = reader.GetInt32(3),
                        Descripcion = reader.GetString(4),
                        ImagenPublicacion = reader.GetString(5),
                        TituloPublicacion = reader.GetString(6)
                    };

                    // Agrega el modelo a la lista
                    Publicaciones.Add(modelo);
                }

                // Retorna la lista
                return Publicaciones;

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
            string query = $""" DELETE FROM `PUBLICACION_USUARIO` WHERE ID = {id}""";

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
