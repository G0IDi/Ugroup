using Api.Models;
using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class TemasDB
    {
        /// <summary>
        /// Obtiene una lista de temas según el ID del tema.
        /// </summary>
        /// <param name="IdTema">ID del tema</param>
        /// <returns>Lista de temas</returns>
        public static async Task<List<Models.Temas>> Listar(int IdTema)
        {
            // Consulta para traer y listar la información de los temas
            string query = $"""SELECT * FROM TEMAS WHERE ID = '{IdTema}';""";

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

                // Lista de temas
                List<Models.Temas> temas = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicación en la fila
                    var modelo = new Models.Temas
                    {
                        IdTema = reader.GetInt32(0),
                        Tema = reader.GetString(1)
                    };

                    // Agrega el modelo a la lista
                    temas.Add(modelo);
                }

                // Retorna la lista de temas
                return temas;
            }
            catch
            {
                // -- Manejo de errores
            }

            return new();
        }
    }
}
