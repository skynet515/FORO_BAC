using ForoBAC_API_QUERYS.Repository.Interfaces;
using DataBaseModel.Models;
using DataBaseModel;
using AutoMapper;
using ForoBAC_API_QUERYS.DTO;
using DataBaseModel.Commands;
using Microsoft.Data.SqlClient;

namespace ForoBAC_API_QUERYS.Repository.Services
{
    public class PreguntasServices : IPreguntas
    {
        private readonly DbContext_Foro _dbContext;
        private readonly IMapper _mapper;

        public PreguntasServices(DbContext_Foro dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<PreguntasDTO> ListarPreguntas()
        {
            List<PreguntasDTO> lstPreguntas = new List<PreguntasDTO>();
            Commands cmd = new Commands(_dbContext);
            List<Preguntas> lst = cmd.ExecuteSqlCommandList<Preguntas>("EXEC sp_ListarPreguntas");
            if (lst.Count > 0)
            {
                lstPreguntas = _mapper.Map<List<Preguntas>, List<PreguntasDTO>>(lst);
            }

            return lstPreguntas;
        }

       
    }
}
