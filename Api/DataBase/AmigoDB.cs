using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class AmigoDB
    {
        /// <summary>
        /// Crea una relación de amistad en la base de datos.
        /// </summary>
        /// <param name="modelo">Modelo de la relación de amistad para crear</param>
        public static async Task<dynamic> CreateAmistad(Models.Amigos modelo)
        {
            // Consulta para crear la relación de amistad
            string query = $"INSERT INTO `AMIGOS` (`M_AMIGO`, `ID_USUARIO`, `ID_AMIGO`) VALUES ('{Convert.ToInt32(modelo.MejorAmigo)}', '{modelo.IdUsuario}', '{modelo.IdAmigo}')";

            try
            {
                // Ejecuta la consulta en la base de datos
                MySqlCommand comando = new MySqlCommand(query, Conexion.GetOneConnection().DataBase);
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y la devuelve como resultado
                return ex.Message;
            }

            return "OK";
        }

        /// <summary>
        /// Obtiene una lista de relaciones de amistad para un usuario específico.
        /// </summary>
        /// <param name="id">ID del usuario</param>
        public static async Task<List<Models.Amigos>> Listar(int id)
        {
            // Consulta para obtener las relaciones de amistad del usuario
            string query = $"SELECT * FROM AMIGOS WHERE ID_USUARIO = '{id}'";

            try
            {
                MySqlCommand comando = new MySqlCommand(query, Conexion.GetOneConnection().DataBase);
                var reader = comando.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    // Si no hay registros, devuelve una lista vacía
                    return new List<Models.Amigos>();
                }

                List<Models.Amigos> amigos = new List<Models.Amigos>();

                // Mapeo de los resultados a objetos de modelo
                while (reader.Read())
                {
                    var modelo = new Models.Amigos
                    {
                        Id = reader.GetInt32(0),
                        IdUsuario = reader.GetInt32(2),
                        IdAmigo = reader.GetInt32(3),
                        MejorAmigo = reader.GetBoolean(1)
                    };

                    amigos.Add(modelo);
                }

                // Devuelve la lista de relaciones de amistad
                return amigos;
            }
            catch
            {
                // Manejo de errores
            }

            return new List<Models.Amigos>();
        }

        /// <summary>
        /// Actualiza una relación de amistad existente.
        /// </summary>
        /// <param name="modelo">Modelo de la relación de amistad actualizada</param>
        /// <param name="id">ID de la relación de amistad</param>
        public static async Task<dynamic> Update(Models.Amigos modelo, int id)
        {
            // Consulta para actualizar la relación de amistad
            string query = $"UPDATE `AMIGOS` SET M_AMIGO = '{(modelo.MejorAmigo ? 1 : 0)}' WHERE ID = '{id}'";

            try
            {
                MySqlCommand comando = new MySqlCommand(query, Conexion.GetOneConnection().DataBase);
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }

        /// <summary>
        /// Elimina una relación de amistad.
        /// </summary>
        /// <param name="id">ID de la relación de amistad</param>
        public static async Task<dynamic> Delete(int id)
        {
            // Consulta para eliminar la relación de amistad
            string query = $"DELETE FROM `AMIGOS` WHERE ID = {id}";

            try
            {
                MySqlCommand comando = new MySqlCommand(query, Conexion.GetOneConnection().DataBase);
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
