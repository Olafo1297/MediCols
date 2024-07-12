using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCols_Aplicattion.Interface
{
    public interface IUtilitiesService
    {
        public Task<dynamic> GetListTipoMedico();
        public Task<dynamic> GetListTipoDocumentoIdentificacion();
        public Task<dynamic> GetListJornadaLaboral();
    }
}
