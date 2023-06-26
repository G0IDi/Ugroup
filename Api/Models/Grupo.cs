namespace Api.Models
{
    public class Grupo
    {

        public int ID { get; set; }
        public string NOMBRE_GRUPO { get; set; } = string.Empty;
        public string DESCRIPCION { get; set; } = string.Empty;
        public int ID_TEMAS { get; set; }
        public int ID_USUARIO { get; set; }

    }
}
