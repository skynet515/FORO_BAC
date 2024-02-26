using AutoMapper;
using System.Runtime.InteropServices;
using DataBaseModel.Models;
using ForoBAC_API_QUERYS.DTO;

namespace ForoBAC_API_QUERYS.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Preguntas, PreguntasDTO>();
            CreateMap<Respuesta, RespuestasDTO>();
        }
    }
}
