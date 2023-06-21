//modelo para la creacion de usuario
using MySql.Data.Types;
using System.Diagnostics.CodeAnalysis;

namespace Api.Models
{
    public class Usuario
    {
     
        public int ID { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;
        
        public string Apellido { get; set; } = string.Empty;

        public string Contrasena { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateOnly Fnacimiento { get; set; }

    }
}
