using ForoBAC_API_CMD.DTO;

namespace ForoBAC_API_CMD.Repository.Interfaces
{
    public interface IUsuario
    {
        int InsertarUsuario(T_UsuarioDTO usuario);
    }
}
