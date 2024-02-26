using DataBaseModel.Models;
using ForoBAC_API_QUERYS.DTO;

namespace ForoBAC_API_QUERYS.Repository.Interfaces
{
    public interface ISesion
    {
        UsuarioDTO IniciarSesion(ValidarCredencialesDTO credenciales);
    }
}
