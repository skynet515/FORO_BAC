using DataBaseModel;
using DataBaseModel.Commands;
using ForoBAC_API_CMD.DTO;
using ForoBAC_API_CMD.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ForoBAC_API_CMD.Repository.Services
{
    public class PreguntaServices:IPregunta
    {
        private readonly DbContext_Foro _dbContext;

        public PreguntaServices(DbContext_Foro dbContext)
        {
            _dbContext = dbContext;
        }

        public int InsertarPregunta(T_PreguntaDTO pregunta)
        {
            int idPregunta = 0;
            Commands cmd = new Commands(_dbContext);
            SqlParameter[] parametersPregunta= new SqlParameter[]
            {
                    new SqlParameter("@idUsuario", pregunta.idUsuario),
                    new SqlParameter("@pregunta", pregunta.pregunta),
                    new SqlParameter("@idPregunta", SqlDbType.Int) { Direction = ParameterDirection.Output }

            };

            int pr = cmd.ExecuteSqlCommand("EXEC sp_InsertarPregunta @idUsuario, @pregunta, @idPregunta OUTPUT", parametersPregunta);

            idPregunta = (int)parametersPregunta[2].Value;

            return idPregunta;
        }

        public int CerrarPregunta(CerrarDTO cerrar)
        {
            int idPregunta = 0;

            Commands cmd = new Commands(_dbContext);
            SqlParameter[] parametersPregunta = new SqlParameter[]
            {
                    new SqlParameter("@idPregunta", cerrar.idPregunta),
                    new SqlParameter("@idModificado", SqlDbType.Int) { Direction = ParameterDirection.Output }

            };

            int id = cmd.ExecuteSqlCommand("EXEC sp_CerrarPregunta @idPregunta, @idModificado OUTPUT", parametersPregunta);

            idPregunta = (int)parametersPregunta[1].Value;


            return idPregunta;
        }
    }
}
