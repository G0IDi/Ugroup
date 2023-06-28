namespace Api.Models
{
    public class PublicacionesUsuario
    {

        public int Id { get; set; }

        public int IdAmigos { get; set; }

        public int IdUsuario { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public string ImagenPublicacion { get; set;} = string.Empty;

        public string TituloPublicacion { get; set; } = string.Empty;
    }
}
