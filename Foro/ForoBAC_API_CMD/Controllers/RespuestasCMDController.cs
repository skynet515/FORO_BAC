using ForoBAC_API_CMD.DTO;
using ForoBAC_API_CMD.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForoBAC_API_CMD.Controllers
{
    [Route("cmd/[controller]")]
    [ApiController]
    public class RespuestasCMDController : ControllerBase
    {
        IRespuesta _respuesta;

        public RespuestasCMDController(IRespuesta respuesta)
        {
            _respuesta = respuesta;
        }

        [HttpPost]
        [Route("InsertarRespuesta")]
        public IActionResult InsertarRespuestas([FromBody] RespuestaDTO respuesta)
        {
            try
            {
                int idRespuesta = _respuesta.InsertarRespuesta(respuesta);
                if (idRespuesta != 0)
                    return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
                else
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "FAILED" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
