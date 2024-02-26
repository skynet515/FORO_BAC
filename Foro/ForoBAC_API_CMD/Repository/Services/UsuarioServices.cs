using AutoMapper;
using DataBaseModel;
using DataBaseModel.Commands;
using DataBaseModel.Models;
using ForoBAC_API_CMD.DTO;
using ForoBAC_API_CMD.Repository.Interfaces;
using ForoBAC_API_QUERYS.DTO;
using ForoBAC_API_QUERYS.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ForoBAC_API_CMD.Repository.Services
{
    public class UsuarioServices : IUsuario
    {
        private readonly DbContext_Foro _dbContext;

        public UsuarioServices(DbContext_Foro dbContext)
        {
            _dbContext = dbContext;
        }

        public int InsertarUsuario(T_UsuarioDTO usuario)
        {
            int idUsuario = 0;
            Commands cmd = new Commands(_dbContext);
            //Validar si el usuarioExiste : 
            UsuarioDTO usuarioDTO = new UsuarioDTO();

            SqlParameter parameter = new SqlParameter("@nombreUsuario", usuario.nombreUsuario);
            Usuario? user = cmd.ExecuteSqlCommand<Usuario>("EXEC sp_ValidarUsuario @nombreUsuario", parameter).FirstOrDefault();
            if (user != null)
            {
                idUsuario = 1; // el usuario existe 
            }
            else
            {
                SqlParameter[] parameterUsuario = new SqlParameter[]
                {
                    new SqlParameter("@nombreUsuario", usuario.nombreUsuario),
                    new SqlParameter("@clave", usuario.clave),
                    new SqlParameter("@idUsuario", SqlDbType.Int) { Direction = ParameterDirection.Output }

                };

                int id = cmd.ExecuteSqlCommand("EXEC sp_InsertarUsuario @nombreUsuario, @clave, @idUsuario OUTPUT", parameterUsuario);
                idUsuario = (int)parameterUsuario[2].Value;
                if (idUsuario < 0)
                {
                    idUsuario = 0;
                }
            }




            return idUsuario;
        }
    }
}
