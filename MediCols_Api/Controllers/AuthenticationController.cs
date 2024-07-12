using MediCols_Aplicattion.Interface;
using MediCols_Aplicattion.Service;
using MediCols_Aplicattion.Utilities;
using MediCols_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediCols_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthenticationController(IUsuarioService usuarioService) { 
        _usuarioService = usuarioService;
        }

        [HttpPost("GetUsuario")]
        public async Task<IActionResult> GetUsuario(Usuario datosUsuario)
        {
            int respuesta = await _usuarioService.GetUsuario(datosUsuario);
            if (respuesta == 1) {

                return StatusCode(StatusCodes.Status200OK, new
                {
                    result = new JsonResult( _usuarioService.ValidateUsuario(datosUsuario))
                });

            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    result = MensajesUtilities.MensajeUsuarioNoExistente
                });
            }


        }
    }
}
