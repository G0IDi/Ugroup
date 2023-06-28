using MySql.Data.MySqlClient;
/// Conexion con la base de datos
/// </summary>
public sealed class Conexion
{

    //======= Propiedades estaticas =======//


    /// <summary>
    /// Obtiene o establece la cadena de conexion
    /// </summary>
    private static string ConnectionString { get; set; } = "";




    /// <summary>
    /// Obtiene la base de datos
    /// </summary>
    public readonly MySqlConnection? DataBase = null;




    /// <summary>
    /// Nueva conexion
    /// </summary>
    private Conexion()
    {
        try
        {

            DataBase = new(ConnectionString ?? "");
            DataBase.Open();
        }
        catch (Exception ex)
        {
            var u = ex;

        }
    }

    /// <summary>
    /// Deconstructor
    /// </summary>
    ~Conexion()
    {
        this.DataBase?.Close();
        this.DataBase?.Dispose();
    }

    /// <summary>
    /// Establece el string de conexion
    /// </summary>
    /// <param name="connectionString">string de conexion</param>
    public static void SetStringConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }

    /// <summary>
    /// Obtiene una conexion a la base de datos
    /// </summary>
    public static Conexion GetOneConnection()
    {
        return new();

    }
}