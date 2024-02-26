using ForoBAC_API_QUERYS.DTO;
using ForoBAC_API_QUERYS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForoBAC_API_QUERYS.Controllers
{
    [Route("querys/[controller]")]
    [ApiController]
    public class RespuestasController : ControllerBase
    {
        IRespuestas _respuestas;

        public RespuestasController(IRespuestas respuestas)
        {
            _respuestas = respuestas;
        }



        [HttpPost]
        [Route("ListarRespuestas")]
        public IActionResult ListarRespuestas([FromBody] PreguntaDTO pregunta)
        {
            try
            {
                List<RespuestasDTO> lst = _respuestas.ListarRespuestas(pregunta);

                if (lst.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, lst);
                else
                    return StatusCode(StatusCodes.Status400BadRequest, lst);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
