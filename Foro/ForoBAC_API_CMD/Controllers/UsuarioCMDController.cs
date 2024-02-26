using ForoBAC_API_CMD.DTO;
using ForoBAC_API_CMD.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForoBAC_API_CMD.Controllers
{
    [Route("cmd/[controller]")]
    [ApiController]
    public class UsuarioCMDController : ControllerBase
    {
        IUsuario _usuario;

        public UsuarioCMDController(IUsuario usuario)
        {
            _usuario = usuario;
        }


        [HttpPost]
        [Route("InsertarUsuario")]
        public IActionResult InsertarUsuario([FromBody] T_UsuarioDTO usuario)
        {
            try
            {
                int idUsuario = _usuario.InsertarUsuario(usuario);

                if(idUsuario > 1 && idUsuario!=1)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
                }else if(idUsuario==1)
                    return StatusCode(StatusCodes.Status200OK, new { message = "DUPLICATE" });
                else
                    return StatusCode(StatusCodes.Status200OK, new { message = "FAILED" });



            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
