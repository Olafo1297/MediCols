using MediCols_Aplicattion.Interface;
using MediCols_Aplicattion.Utilities;
using MediCols_Domain.Entity;
using MediCols_Infrastructure.Interface;

namespace MediCols_Aplicattion.Service
{
    public class MedicoService: IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<dynamic> GetMedicos()
        {
            return await _medicoRepository.GetMedicos();
        }

        public async Task<string> CreateMedicos(Medico datosMedico)
        {
            try
            {
                int respuesta = await _medicoRepository.CreateMedicos(datosMedico);
                return respuesta == 1 ? MensajesUtilities.MensajeMedicoInsercionExitosa : MensajesUtilities.MensajeMedicoInsercionNoExitosa;
            }
            catch (Exception)
            {
                return MensajesUtilities.MensajeMedicoInsercionNoExitosa;
            }
        }

        public async Task<string> UpdateMedicos(Medico datosMedico)
        {
            try
            {
                int respuesta = await _medicoRepository.UpdateMedicos(datosMedico);
                return respuesta == 1 ? MensajesUtilities.MensajeMedicoActualizacionExitosa : MensajesUtilities.MensajeMedicoActualizacionNoExitosa;
            }
            catch (Exception)
            {
                return MensajesUtilities.MensajeMedicoActualizacionNoExitosa;
            }
        }

        public async Task<string> DeleteMedicos(string numeroDocumento)
        {
            try
            {
                int respuesta = await _medicoRepository.DeleteMedicos(numeroDocumento);
                return respuesta == 1 ? MensajesUtilities.MensajeMedicoEliminacionExitosa : MensajesUtilities.MensajeMedicoEliminacionNoExitosa;
            }
            catch (Exception)
            {
                return MensajesUtilities.MensajeMedicoEliminacionNoExitosa;
            }
        }
    }
}
