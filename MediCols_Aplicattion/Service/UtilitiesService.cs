using MediCols_Aplicattion.Interface;
using MediCols_Infrastructure.Interface;

namespace MediCols_Aplicattion.Service
{
    public class UtilitiesService: IUtilitiesService
    {
        private readonly IUtilitiesRepository _UtilitiesRepository;

        public UtilitiesService(IUtilitiesRepository utilitiesRepository)
        {
            _UtilitiesRepository = utilitiesRepository;
        }

        public async Task<dynamic> GetListTipoMedico()
        {
            return await _UtilitiesRepository.GetListTipoMedico();
        }

        public async Task<dynamic> GetListTipoDocumentoIdentificacion()
        {
            return await _UtilitiesRepository.GetListTipoDocumentoIdentificacion();
        }

        public async Task<dynamic> GetListJornadaLaboral()
        {
            return await _UtilitiesRepository.GetListJornadaLaboral();
        }
    }
}
