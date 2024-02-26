namespace ForoBAC_API_QUERYS.DTO
{
    public class RespuestasDTO
    {
        public int idRespuesta { get; set; }
        public int idPregunta { get; set; }
        public string? respuesta { get; set; }
        public string? nombreUsuario { get; set; }
    }
}
