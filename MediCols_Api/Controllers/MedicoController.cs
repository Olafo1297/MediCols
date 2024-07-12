using MediCols_Aplicattion.Interface;
using MediCols_Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCols_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        /// <summary>
        /// Metodo que lista todos los medicos registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMedicos")]
        public async Task<IActionResult> GetMedicos()
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                result = new JsonResult(await _medicoService.GetMedicos())
            });
        }

        /// <summary>
        /// Metodo que registra un medico 
        /// </summary>
        /// <param name="datosMedico"></param>
        /// <returns></returns>
        [HttpPost("CreateMedicos")]
        public async Task<IActionResult> CreateMedico(Medico datosMedico)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    result = await _medicoService.CreateMedicos(datosMedico)
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

        /// <summary>
        /// Metodo par actualizar un medico
        /// </summary>
        /// <param name="datosMedico"></param>
        /// <returns></returns>
        [HttpPut("UpdateMedicos")]
        public async Task<IActionResult> UpdateMedicos(Medico datosMedico)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    result = await _medicoService.UpdateMedicos(datosMedico)
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

        /// <summary>
        /// Metodo para eliminar un medico
        /// </summary>
        /// <param name="numeroDocumento"></param>
        /// <returns></returns>
        [HttpGet("DeleteMedicos")]
        public async Task<IActionResult> DeleteMedicos(string numeroDocumento)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new
                {
                    result = await _medicoService.DeleteMedicos(numeroDocumento)
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

