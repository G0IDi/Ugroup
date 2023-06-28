using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class PublicacionUserDB
    {
        /// <summary>
        /// Crea una publicación de usuario en la base de datos
        /// </summary>
        /// <param name="modelo">Modelo de la publicación de usuario para crear</param>
        public static async Task<dynamic> Create(Models.PublicacionesUsuario modelo)
        {
            // Consulta para crear la publicación de usuario
            string query = $""" INSERT INTO `PUBLICACION_USUARIO`(`ID`,`ID_AMIGOS`, `ID_USUARIO`, `DESCRIPCION`, `IMAGEN_PUBLICACION`, `TITULO_PUBLICACION`) VALUES ('{modelo.Id}','{modelo.IdAmigos}','{modelo.IdUsuario}', '{modelo.Descripcion}', '{modelo.ImagenPublicacion}', '{modelo.TituloPublicacion}')""";

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // Ejecuta la consulta sin obtener ningún resultado
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }

        /// <summary>
        /// Actualiza una publicación de usuario en la base de datos
        /// </summary>
        /// <param name="id">ID de la publicación de usuario</param>
        /// <returns></returns>
        public static async Task<dynamic> Update(Models.PublicacionesUsuario modelo, int id)
        {
            // Consulta para actualizar la información de la publicación de usuario
            string query = $""" UPDATE `PUBLICACION_USUARIO` SET DESCRIPCION  = '{modelo.Descripcion}', IMAGEN_PUBLICACION = '{modelo.ImagenPublicacion}', TITULO_PUBLICACION = '{modelo.TituloPublicacion}' WHERE ID = {id}  """;

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // Ejecuta la consulta sin obtener ningún resultado
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }

        public static async Task<List<Models.PublicacionesUsuario>> Listar()
        {
            // Consulta para traer y listar la información de las publicaciones de usuarios
            string query = $"""SELECT * FROM PUBLICACION_USUARIO;""";

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

                // Lista de publicaciones de usuarios
                List<Models.PublicacionesUsuario> Publicaciones = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicación en la fila
                    var modelo = new Models.PublicacionesUsuario
                    {
                        Id = reader.GetInt32(0),
                        IdAmigos = reader.GetInt32(1),
                        IdUsuario = reader.GetInt32(2),
                        Descripcion = reader.GetString(3),
                        ImagenPublicacion = reader.GetString(4),
                        TituloPublicacion = reader.GetString(5)
                    };

                    // Agrega el modelo a la lista
                    Publicaciones.Add(modelo);
                }

                // Retorna la lista de publicaciones de usuarios
                return Publicaciones;
            }
            catch
            {
                // -- Manejo de errores
            }

            return new();
        }

        /// <summary>
        /// Elimina una publicación de usuario de la base de datos
        /// </summary>
        /// <param name="id">ID de la publicación de usuario</param>
        /// <returns></returns>
        public static async Task<dynamic> Delete(int id)
        {
            // Consulta para eliminar la información de la publicación de usuario
            string query = $""" DELETE FROM `PUBLICACION_USUARIO` WHERE ID = {id}""";

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // Ejecuta la consulta sin obtener ningún resultado
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
