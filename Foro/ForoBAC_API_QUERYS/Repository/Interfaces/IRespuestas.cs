using ForoBAC_API_QUERYS.DTO;

namespace ForoBAC_API_QUERYS.Repository.Interfaces
{
    public interface IRespuestas
    {
        List<RespuestasDTO> ListarRespuestas(PreguntaDTO pregunta);
    }
}
