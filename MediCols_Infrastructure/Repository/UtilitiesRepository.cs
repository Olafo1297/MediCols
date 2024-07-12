using Dapper;
using MediCols_Infrastructure.Data;
using MediCols_Infrastructure.Interface;
using System.Data;
using System.Data.SqlClient;

namespace MediCols_Infrastructure.Repository
{
    public class UtilitiesRepository: IUtilitiesRepository
    {
        public readonly IDbConnection Connection;

        public UtilitiesRepository(ConnectionService connectionService)
        {
            string connsql = connectionService.getConnection();

            Connection = new SqlConnection(connsql);
        }
        /// <summary>
        /// Metodo que llama funcion GET_TIPOMEDICO que trae todos los tipo de medico
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> GetListTipoMedico()
        {
            DynamicParameters parametro = new DynamicParameters();

            IEnumerable<dynamic> lista = await Connection.QueryAsync<dynamic>("GET_TIPOMEDICO", parametro, commandType: CommandType.StoredProcedure);

            return lista.ToList();
        }
        /// <summary>
        /// Metodo que llama la funcion GET_TIPODOCUMENTOIDENTIFICACION que trae todos los tipos de documentos de identificacion
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> GetListTipoDocumentoIdentificacion()
        {
            DynamicParameters parametro = new DynamicParameters();

            IEnumerable<dynamic> lista = await Connection.QueryAsync<dynamic>("GET_TIPODOCUMENTOIDENTIFICACION", parametro, commandType: CommandType.StoredProcedure);

            return lista.ToList();
        }
        /// <summary>
        /// Metodo que llama la funcion GET_JORNADALABORAL que trae las jornadas laborales
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> GetListJornadaLaboral()
        {
            DynamicParameters parametro = new DynamicParameters();

            IEnumerable<dynamic> lista = await Connection.QueryAsync<dynamic>("GET_JORNADALABORAL", parametro, commandType: CommandType.StoredProcedure);

            return lista.ToList();
        }
    }
}
