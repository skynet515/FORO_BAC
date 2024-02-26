using ForoBAC_API_CMD.DTO;

namespace ForoBAC_API_CMD.Repository.Interfaces
{
    public interface IPregunta
    {
        int InsertarPregunta(T_PreguntaDTO pregunta);
        int CerrarPregunta(CerrarDTO cerrar);
    }
}
