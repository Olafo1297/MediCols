using MediCols_Aplicattion.Interface;
using MediCols_Aplicattion.Service;
using MediCols_Aplicattion.Utilities;
using MediCols_Domain.Entity;
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

        /// <summary>
        /// Metodo que valida la existencia del usuario y si existe genera token requerido para llamado otros endpoints
        /// </summary>
        /// <param name="datosUsuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo que permite el flujo de creacion de Usuario
        /// </summary>
        /// <param name="datosUsuario"></param>
        /// <returns></returns>
        [HttpPost("CreateUsuario")]
        public async Task<IActionResult> CreateUsuario(Usuario datosUsuario)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    result = await _usuarioService.CreateUsuarios(datosUsuario)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    result = ex.Message + " " + ex.StackTrace
                });
            }
        }
    }
}
