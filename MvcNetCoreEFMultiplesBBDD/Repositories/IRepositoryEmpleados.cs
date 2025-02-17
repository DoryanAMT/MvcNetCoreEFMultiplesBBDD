using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public interface IRepositoryEmpleados
    {
        Task<List<EmpleadoView>> GetEmpleadosAsync();
        Task<EmpleadoView> FindEmpleado(int idEmpleado);

    }
}
