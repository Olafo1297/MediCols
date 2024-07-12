using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCols_Domain.Entity
{
    public class Medico
    {
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public string NumeroDocumento { get; set; }
        public int IdTipoMedico { get; set; }
        public int IdJornadaLaboral { get; set; }
        public int IdTipoDocumentoIdentificacion { get; set; }
    }
}
