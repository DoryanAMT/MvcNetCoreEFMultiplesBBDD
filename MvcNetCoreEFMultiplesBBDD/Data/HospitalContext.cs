using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Models;

namespace MvcNetCoreEFMultiplesBBDD.Data
{
    public class HospitalContext:DbContext
    {
        public HospitalContext(DbContextOptions options)
            :base(options) { }
        public DbSet<EmpleadoView> EmpleadoViews { get; set; }
    }
}
