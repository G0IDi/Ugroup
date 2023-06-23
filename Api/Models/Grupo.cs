namespace Api.Models
{
    public class Grupo
    {

        public int Id { get; set; }

        public int IdTemas { get; set; }

        public int IdUsuario { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

    }
}
