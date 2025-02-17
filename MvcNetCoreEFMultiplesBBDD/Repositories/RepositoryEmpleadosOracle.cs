using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;
using Oracle.ManagedDataAccess.Client;

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosOracle: IRepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleadosOracle(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            string sql = "begin ";
            sql += "SP_ALL_VEMPLEADOS(:p_cursor_empleados);";
            sql += " end;";
            OracleParameter pamCursor = new OracleParameter();
            pamCursor.ParameterName = "p_cursor_empleados";
            pamCursor.Value = null;
            pamCursor.Direction = System.Data.ParameterDirection.Output;
            //  DEBEMOS INDICAR EL TIPO DE DATO DE ORACLE CURSOR
            pamCursor.OracleDbType = OracleDbType.RefCursor;
            var consulta = this.context.EmpleadoViews
                .FromSqlRaw(sql, pamCursor);
            return await consulta.ToListAsync();
        }
        public Task<EmpleadoView> FindEmpleado(int idEmpleado)
        {
            throw new NotImplementedException();
        }

    }
}
