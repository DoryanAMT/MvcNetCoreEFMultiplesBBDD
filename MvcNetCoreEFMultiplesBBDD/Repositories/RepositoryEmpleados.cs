using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    #region
    //    create or replace view V_EMPLEADOS
    //as
    //  select EMP.EMP_NO as IDEMPLEADO
    //  , EMP.APELLIDO as APELLIDO
    //  , EMP.OFICIO as OFICIO
    //  , EMP.SALARIO as  SALARIO
    //  , DEPT.DNOMBRE as DEPARTAMENTO
    //  , DEPT.LOC as LOCALIDAD
    //  from EMP
    //  inner join DEPT
    //  on EMP.DEPT_NO = DEPT.DEPT_NO;
    //    create procedure SP_ALL_VEMPLEADOS
    //as
    //select* from V_EMPLEADOS
    //go

    //create or replace procedure SP_ALL_VEMPLEADOS
    //(p_cursor_empleados out sys_refcursor)
    //as
    //begin
    //open p_cursor_empleados for
    //select* from V_EMPLEADOS;
    //end;
    #endregion
    public class RepositoryEmpleados: IRepositoryEmpleados
    {
        HospitalContext context;
        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            string sql = "SP_ALL_VEMPLEADOS";
            var consulta = this.context.EmpleadoViews.FromSqlRaw(sql);
            //var consulta = from datos in this.context.EmpleadoViews
            //               select datos;
            return await consulta.ToListAsync();
        }
        public async Task<EmpleadoView> FindEmpleado
            (int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadoViews
                           where datos.IdEmpleado == idEmpleado
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }
    }
}
