using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;
using System.Diagnostics.Metrics;

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    #region
    //alter view V_EMPLEADOS
    //as
    //    select EMP.EMP_NO as IDEMPLEADO
    //    , EMP.APELLIDO as APELLIDO
    //    , EMP.OFICIO as OFICIO
    //    , EMP.SALARIO as  SALARIO
    //    , DEPT.DNOMBRE as DEPARTAMENTO
    //    , DEPT.LOC as LOCALIDAD
    //    from EMP
    //    inner join DEPT
    //    on EMP.DEPT_NO = DEPT.DEPT_NO;

    //    select* from V_EMPLEADOS
    //DELIMITER $$
    //create procedure SP_ALL_VEMPLEADOS()
    //begin
    //select* from V_EMPLEADOS;
    //end $$
    //DELIMITER ;
    #endregion
    public class RepositoryEmpleadosMySql : IRepositoryEmpleados
    {
        HospitalContext context;
        public RepositoryEmpleadosMySql(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            string sql = "CALL SP_ALL_VEMPLEADOS()";
            var consulta = this.context.EmpleadoViews.FromSqlRaw(sql);
            return await consulta.ToListAsync();
            //var consulta = from datos in this.context.EmpleadoViews
            //               select datos;
            //return await consulta.ToListAsync();
        }
        public async Task<EmpleadoView> FindEmpleado(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadoViews
                           where datos.IdEmpleado == idEmpleado
                           select datos;
            return await consulta.FirstAsync();
        }

    }
}
