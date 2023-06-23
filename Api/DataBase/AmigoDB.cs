using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class AmigoDB
    {

        /// <summary>
        /// Crea un usuario en la base de datos
        /// </summary>
        /// <param name="modelo">Modelo del usuario para crear</param>
        public static async Task<dynamic> CreateAmistad(Models.Amigos modelo)
        {

            // Consulta para crear user
            string query = $""" INSERT INTO `AMIGOS` (`M_AMIGO`, `ID_USUARIO` ,`ID_AMIGO`)  VALUES ('{Convert.ToInt32(modelo.MejorAmigo)}','{modelo.IdUsuario}','{modelo.IdAmigo}')""";

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

        public static async Task<List<Models.Amigos>> Listar(int id)
        {

            // Consulta para traer y listar la info del user
            string query = $"""SELECT * FROM AMIGOS WHERE ID_USUARIO = '{id}';""";

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
                List<Models.Amigos> amigos = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicacion en la fila
                    var modelo = new Models.Amigos
                    {
                        Id = reader.GetInt32(0),
                        IdUsuario = reader.GetInt32(2),
                        IdAmigo = reader.GetInt32(3),
                        MejorAmigo = reader.GetBoolean(1)
                    };

                    // Agrega el modelo a la lista
                    amigos.Add(modelo);
                }

                // Retorna la lista
                return amigos;

            }
            catch
            {
                // -- Manejor de errores
            }


            return new();

        }

        public static async Task<dynamic> Delete(int id)
        {

            // Consulta para eliminar la info del user
            string query = $""" DELETE FROM `AMIGOS` WHERE ID = {id}""";

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
