using AutoMapper;
using DataBaseModel;
using DataBaseModel.Commands;
using DataBaseModel.Models;
using ForoBAC_API_QUERYS.DTO;
using ForoBAC_API_QUERYS.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ForoBAC_API_QUERYS.Repository.Services
{
    public class RespuestasServices: IRespuestas
    {
        private readonly DbContext_Foro _dbContext;
        private readonly IMapper _mapper;


        public RespuestasServices(DbContext_Foro dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<RespuestasDTO> ListarRespuestas(PreguntaDTO pregunta)
        {
            List<RespuestasDTO> lstRespuestas = new List<RespuestasDTO>();
            Commands cmd = new Commands(_dbContext);
            SqlParameter parameter = new SqlParameter("@idPregunta", pregunta.idPregunta);
            List<Respuesta> lst = cmd.ExecuteSqlCommandList<Respuesta>("EXEC sp_RespuestasxUsuario @idPregunta", parameter);
            if (lst.Count > 0)
            {
                lstRespuestas = _mapper.Map<List<Respuesta>, List<RespuestasDTO>>(lst);
            }

            return lstRespuestas;
        }
    }
}
