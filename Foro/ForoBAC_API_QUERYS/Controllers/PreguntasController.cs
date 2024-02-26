using ForoBAC_API_QUERYS.DTO;
using ForoBAC_API_QUERYS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ForoBAC_API_QUERYS.Controllers
{
    [Route("querys/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        IPreguntas _preguntas;

        public PreguntasController(IPreguntas preguntas)
        {
            _preguntas = preguntas;
        }

        [HttpGet]
        [Route("ListaPreguntas")]
        public IActionResult ListarPreguntas()
        {
            try
            {
                List<PreguntasDTO> lst = _preguntas.ListarPreguntas();

                if (lst.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, lst);
                else
                    return StatusCode(StatusCodes.Status400BadRequest, lst);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

       
    }
}
