namespace ForoBAC_API_QUERYS.DTO
{
    public class PreguntasDTO
    {
        public int idPregunta { get; set; }
        public int idUsuario { get; set; }
        public string? pregunta { get; set; }
        public string? nombreUsuario { get; set; }
        public bool Activo { get; set; }

    }
}
