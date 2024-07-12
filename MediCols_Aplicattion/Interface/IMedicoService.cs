using MediCols_Domain.Entity;

namespace MediCols_Aplicattion.Interface
{
    public interface IMedicoService
    {
        public Task<dynamic> GetMedicos();
        public Task<string> CreateMedicos(Medico datosMedico);
        public Task<string> UpdateMedicos(Medico datosMedico);
        public Task<string> DeleteMedicos(string numeroDocumento);
    }
}
