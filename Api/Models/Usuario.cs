
namespace Api.Models
{
    public class Usuario
    {
     
        public int ID { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public string Contraseña { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
