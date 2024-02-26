using AutoMapper;
using ForoBAC_API_QUERYS.DTO;
using ForoBAC_API_QUERYS.Repository.Interfaces;
using DataBaseModel;
using DataBaseModel.Commands;
using Microsoft.Data.SqlClient;
using DataBaseModel.Models;

namespace ForoBAC_API_QUERYS.Repository.Services
{
    public class SesionServices : ISesion
    {
        private readonly IMapper _mapper;
        private readonly DbContext_Foro _dbContext;

        public SesionServices(IMapper mapper, DbContext_Foro dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public UsuarioDTO IniciarSesion(ValidarCredencialesDTO credenciales)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            Commands cmd = new Commands(_dbContext);

            SqlParameter parameter = new SqlParameter("@nombreUsuario", credenciales.nombreUsuario);

            //Validar existencia del usuario
            Usuario? usuario = cmd.ExecuteSqlCommand<Usuario>("EXEC sp_ValidarUsuario @nombreUsuario", parameter).FirstOrDefault();
            if (usuario != null)
            {
                if(usuario.clave == credenciales.clave)
                {
                    usuarioDTO = _mapper.Map<Usuario, UsuarioDTO>(usuario);
                }
            }

            return usuarioDTO;
        }
    }
}
