namespace MediCols_Infrastructure.Interface
{
    public interface IUtilitiesRepository
    {
        public Task<dynamic> GetListTipoMedico();
        public Task<dynamic> GetListTipoDocumentoIdentificacion();
        public Task<dynamic> GetListJornadaLaboral();

    }
}
