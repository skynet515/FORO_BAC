using ForoBAC_API_CMD.DTO;
using ForoBAC_API_CMD.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace ForoBAC_API_CMD.Controllers
{
    [Route("cmd/[controller]")]
    [ApiController]
    public class PreguntasCMDController : ControllerBase
    {
        IPregunta _pregunta;

        public PreguntasCMDController(IPregunta pregunta)
        {
            _pregunta = pregunta;
        }


        [HttpPost]
        [Route("InsertarPregunta")]
        public IActionResult InsertarPregunta([FromBody] T_PreguntaDTO pregunta)
        {
            try
            {
                int idPregunta = _pregunta.InsertarPregunta(pregunta);
                if (idPregunta != 0)
                    return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
                else
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "FAILED" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("CerrarPregunta")]
        public IActionResult CerrarPregunta([FromBody] CerrarDTO cerrar)
        {
            try
            {

                int pr = _pregunta.CerrarPregunta(cerrar);

                if (pr != 0)
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
