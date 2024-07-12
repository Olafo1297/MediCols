using MediCols_Aplicattion.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCols_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilitiesService _UtilitiesService;

        public UtilitiesController(IUtilitiesService utilitiesService)
        {
            _UtilitiesService = utilitiesService;
        }

        /// <summary>
        /// Metodo que lista los tipos de medicos registrados en dba
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListTipoMedico")]
        public async Task<IActionResult> GetListTipoMedico()
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                result = new JsonResult(await _UtilitiesService.GetListTipoMedico())
            });
        }

        /// <summary>
        /// Metodo que lista los tipos de documentos de identificacion registrados en dba
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListTipoDocumentoIdentificacion")]
        public async Task<IActionResult> GetListTipoDocumentoIdentificacion()
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                result = new JsonResult(await _UtilitiesService.GetListTipoDocumentoIdentificacion())
            });
        }

        /// <summary>
        /// Metodo que lista las jornadas laborales registradas en dba
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListJornadaLaboral")]
        public async Task<IActionResult> GetListJornadaLaboral()
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                result = new JsonResult(await _UtilitiesService.GetListJornadaLaboral())
            });
        }
    }
}
