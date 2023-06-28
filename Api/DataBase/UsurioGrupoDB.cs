using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Api.DataBase
{
    public class UsurioGrupoDB
    {
        /// <summary>
        /// Crea una relación entre un usuario y un grupo en la base de datos.
        /// </summary>
        /// <param name="modelo">Modelo de la relación usuario-grupo para crear</param>
        /// <returns>Estado de la operación</returns>
        public static async Task<dynamic> Create(Models.UsuarioGrupo modelo)
        {
            // Consulta para crear la relación usuario-grupo
            string query = $""" INSERT INTO `USUARIOS_GRUPO` (`ID`,`ID_GRUPOS`, `ID_USUARIO` )  VALUES ('{modelo.Id}','{modelo.IdGrupos}', '{modelo.IdUsuario}')""";

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID de la relación insertada
                await comando.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "OK";
        }

        /// <summary>
        /// Obtiene una lista de relaciones usuario-grupo según el ID del grupo.
        /// </summary>
        /// <param name="IdGrupos">ID del grupo</param>
        /// <returns>Lista de relaciones usuario-grupo</returns>
        public static async Task<List<Models.UsuarioGrupo>> ListarGrupos(int IdGrupos)
        {
            // Consulta para traer y listar la información de las relaciones usuario-grupo
            string query = $"SELECT * FROM `USUARIOS_GRUPO` WHERE ID_GRUPOS = '{IdGrupos}';";

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

                // Lista de relaciones usuario-grupo
                List<Models.UsuarioGrupo> Grupos = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicación en la fila
                    var modelo = new Models.UsuarioGrupo
                    {
                        Id = reader.GetInt32(0),
                        IdGrupos = reader.GetInt32(1),
                        IdUsuario = reader.GetInt32(2),
                    };

                    // Agrega el modelo a la lista
                    Grupos.Add(modelo);
                }

                // Retorna la lista de relaciones usuario-grupo
                return Grupos;
            }
            catch
            {
                // -- Manejo de errores
            }

            return new();
        }

        /// <summary>
        /// Obtiene una lista de relaciones usuario-grupo según el ID del usuario.
        /// </summary>
        /// <param name="IdUsuario">ID del usuario</param>
        /// <returns>Lista de relaciones usuario-grupo</returns>
        public static async Task<List<Models.UsuarioGrupo>> ListarUsuario(int IdUsuario)
        {
            // Consulta para traer y listar la información de las relaciones usuario-grupo
            string query = $"SELECT * FROM `USUARIOS_GRUPO` WHERE ID_USUARIO = '{IdUsuario}';";

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

                // Lista de relaciones usuario-grupo
                List<Models.UsuarioGrupo> Grupos = new();

                // Mapeo
                while (reader.Read())
                {
                    // Mapeo de los modelos mediante su ubicación en la fila
                    var modelo = new Models.UsuarioGrupo
                    {
                        Id = reader.GetInt32(0),
                        IdGrupos = reader.GetInt32(1),
                        IdUsuario = reader.GetInt32(2),
                    };

                    // Agrega el modelo a la lista
                    Grupos.Add(modelo);
                }

                // Retorna la lista de relaciones usuario-grupo
                return Grupos;
            }
            catch
            {
                // -- Manejo de errores
            }

            return new();
        }

        /// <summary>
        /// Elimina una relación usuario-grupo de la base de datos.
        /// </summary>
        /// <param name="id">ID de la relación usuario-grupo</param>
        /// <returns>Estado de la operación</returns>
        public static async Task<dynamic> Delete(int id)
        {
            // Consulta para eliminar la información de la relación usuario-grupo
            string query = $""" DELETE FROM `USUARIOS_GRUPO` WHERE ID = {id}""";

            // Ejecución
            try
            {
                // Comando
                MySqlCommand comando = new(query, Conexion.GetOneConnection().DataBase);

                // ID de la relación eliminada
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
