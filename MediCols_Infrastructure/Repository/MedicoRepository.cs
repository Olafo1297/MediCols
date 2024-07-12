using Dapper;
using MediCols_Domain.Entity;
using MediCols_Infrastructure.Data;
using MediCols_Infrastructure.Interface;
using System.Data;
using System.Data.SqlClient;

namespace MediCols_Infrastructure.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        public readonly IDbConnection Connection;

        public MedicoRepository(ConnectionService connectionService)
        {
            string connsql = connectionService.getConnection();

            Connection = new SqlConnection(connsql);
        }

        /// <summary>
        /// Metodo que llama la funcion GET_MEDICOS que trae todos los Medicos de la base de datos SQL
        /// </summary>
        /// <returns></returns>
        public async Task<dynamic> GetMedicos()
        {
            DynamicParameters parametro = new DynamicParameters();

            IEnumerable<dynamic> lista = await Connection.QueryAsync<dynamic>("GET_MEDICOS", parametro, commandType: CommandType.StoredProcedure);

            return lista.ToList();
        }

        /// <summary>
        /// Metodo que llama funcion CREATE_MEDICOS para insertar un medico en la dba
        /// </summary>
        /// <param name="datosMedico"></param>
        /// <returns></returns>
        public async Task<int> CreateMedicos(Medico datosMedico)
        {
            try
            {
                DynamicParameters parametro = new DynamicParameters();
                parametro.Add("@NombreCompleto", datosMedico.NombreCompleto, DbType.String);
                parametro.Add("@Edad", datosMedico.Edad, DbType.Int16);
                parametro.Add("@NumeroDocumento", datosMedico.NumeroDocumento, DbType.String);
                parametro.Add("@IdTipoMedico", datosMedico.IdTipoMedico, DbType.Int64);
                parametro.Add("@IdJornadaLaboral", datosMedico.IdJornadaLaboral, DbType.Int64);
                parametro.Add("@IdTipoDocumentoIdentificacion", datosMedico.IdTipoDocumentoIdentificacion, DbType.Int64);
                int respuesta = await Connection.ExecuteAsync("CREATE_MEDICOS", parametro, commandType: CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Metodo que llama funcion UpdateMedicos para actualizar un medico en la dba
        /// </summary>
        /// <param name="datosMedico"></param>
        /// <returns></returns>
        public async Task<int> UpdateMedicos(Medico datosMedico)
        {
            try
            {
                DynamicParameters parametro = new DynamicParameters();
                parametro.Add("@NombreCompleto", datosMedico.NombreCompleto, DbType.String);
                parametro.Add("@Edad", datosMedico.Edad, DbType.Int16);
                parametro.Add("@NumeroDocumento", datosMedico.NumeroDocumento, DbType.String);
                parametro.Add("@IdTipoMedico", datosMedico.IdTipoMedico, DbType.Int64);
                parametro.Add("@IdJornadaLaboral", datosMedico.IdJornadaLaboral, DbType.Int64);
                parametro.Add("@IdTipoDocumentoIdentificacion", datosMedico.IdTipoDocumentoIdentificacion, DbType.Int64);
                int respuesta = await Connection.ExecuteAsync("UPDATE_MEDICOS", parametro, commandType: CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Metodo que llama funcion DELETE_MEDICOS para eliminar un medico en la dba
        /// </summary>
        /// <param name="numeroDocumento"></param>
        /// <returns></returns>
        public async Task<int> DeleteMedicos(string numeroDocumento)
        {
            try
            {
                DynamicParameters parametro = new DynamicParameters();
                parametro.Add("@NumeroDocumento", numeroDocumento, DbType.String);
                int respuesta = await Connection.ExecuteAsync("DELETE_MEDICOS", parametro, commandType: CommandType.StoredProcedure);

                return respuesta;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
