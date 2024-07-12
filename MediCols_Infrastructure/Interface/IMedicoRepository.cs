using MediCols_Domain.Entity;

namespace MediCols_Infrastructure.Interface
{
    public interface  IMedicoRepository
    {
        public Task<dynamic> GetMedicos();
        public Task<int> CreateMedicos(Medico datosMedico);
        public Task<int> UpdateMedicos(Medico datosMedico);
        public Task<int> DeleteMedicos(string numeroDocumento);
    }
}
