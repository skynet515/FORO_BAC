using ForoBAC_API_QUERYS.DTO;
using ForoBAC_API_QUERYS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForoBAC_API_QUERYS.Controllers
{
    [Route("querys/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        ISesion _sesion;

        public UsuarioController(ISesion sesion)
        {
            _sesion = sesion;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] ValidarCredencialesDTO credenciales)
        {
            try
            {

                UsuarioDTO dto = _sesion.IniciarSesion(credenciales);
                if (dto != null && dto.idRol > 0 && dto.idUsuario > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, dto);
                }
                else
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "Sesion Failded" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }


        }
    }
}
