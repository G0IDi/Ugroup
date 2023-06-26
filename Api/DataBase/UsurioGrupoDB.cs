using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class UsurioGrupoDB
    {
        public static async Task<dynamic> Create(Models.UsuarioGrupo modelo)
        {

            // Consulta para crear user
            string query = $""" INSERT INTO `USUARIOS_GRUPO` (`ID`,`ID_GRUPOS`, `ID_USUARIO` )  VALUES ('{modelo.Id}','{modelo.IdGrupos}', '{modelo.IdUsuario}')""";

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

        public static async Task<List<Models.UsuarioGrupo>> Listar(int IdGrupos)
        {

            // Consulta para traer y listar la info del user
            string query = $"SELECT * FROM `USUARIOS_GRUPO` WHERE ID_GRUPOS = '{IdGrupos}';";



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
                List<Models.UsuarioGrupo> Grupos = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicacion en la fila
                    var modelo = new Models.UsuarioGrupo
                    {
                        Id = reader.GetInt32(0),
                        IdGrupos = reader.GetInt32(1),
                        IdUsuario = reader.GetInt32(2),
                    };

                    // Agrega el modelo a la lista
                    Grupos.Add(modelo);
                }

                // Retorna la lista
                return Grupos;

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
            string query = $""" DELETE FROM `USUARIOS_GRUPO` WHERE ID = {id}""";

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
