using Api.Models;
using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class TemasDB
    {
        public static async Task<List<Models.Temas>> Listar(int IdTema)
        {

            // Consulta para traer y listar la info del user
            string query = $"""SELECT * FROM TEMAS WHERE ID = '{IdTema}';""";

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
                List<Models.Temas> temas = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicacion en la fila
                    var modelo = new Models.Temas
                    {
                        IdTema = reader.GetInt32(0),
                        Tema = reader.GetString(1),

                    };

                    // Agrega el modelo a la lista
                    temas.Add(modelo);
                }

                // Retorna la lista
                return temas;

            }
            catch
            {
                // -- Manejor de errores
            }


            return new();

        }
    }
}
