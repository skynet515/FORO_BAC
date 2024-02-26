using DataBaseModel;
using DataBaseModel.Commands;
using ForoBAC_API_CMD.DTO;
using ForoBAC_API_CMD.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ForoBAC_API_CMD.Repository.Services
{
    public class RespuestaServices: IRespuesta
    {
        private readonly DbContext_Foro _dbContext;

        public RespuestaServices(DbContext_Foro dbContext)
        {
            _dbContext = dbContext;
        }

        public int InsertarRespuesta(RespuestaDTO respuesta)
        {
            int idRespuesta = 0;
            Commands cmd = new Commands(_dbContext);
            SqlParameter[] parametersRespuesta = new SqlParameter[]
            {
                    new SqlParameter("@idUsuario", respuesta.idUsuario),
                    new SqlParameter("@idPregunta", respuesta.idPregunta),
                    new SqlParameter("@respuesta", respuesta.respuesta),
                    new SqlParameter("@idRespuesta", SqlDbType.Int) { Direction = ParameterDirection.Output }

            };

            int pr = cmd.ExecuteSqlCommand("EXEC sp_InsertarRespuesta @idUsuario, @idPregunta, @respuesta, @idRespuesta OUTPUT", parametersRespuesta);

            idRespuesta = (int)parametersRespuesta[3].Value;

            return idRespuesta;

        }
    }
}
