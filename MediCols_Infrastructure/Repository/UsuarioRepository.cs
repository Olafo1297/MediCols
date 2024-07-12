using Dapper;
using MediCols_Domain.Entity;
using MediCols_Infrastructure.Data;
using MediCols_Infrastructure.Interface;
using System.Data;
using System.Data.SqlClient;

namespace MediCols_Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly IDbConnection Connection;

        public UsuarioRepository(ConnectionService connectionService)
        {
            string connsql = connectionService.getConnection();

            Connection = new SqlConnection(connsql);
        }
        public async Task<int> GetUsuario(Usuario datosUsuario)
        {
            DynamicParameters parametro = new DynamicParameters();
            parametro.Add("@usuario", datosUsuario.Usuari, DbType.String);
            parametro.Add("@contra", datosUsuario.Contra, DbType.String);

            IEnumerable<dynamic> lista = await Connection.QueryAsync<dynamic>("GET_USUARIO", parametro, commandType: CommandType.StoredProcedure);

            return lista.Count() > 0 ? 1 : 0;
        }
    }
}
