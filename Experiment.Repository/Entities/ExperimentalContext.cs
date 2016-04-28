using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Repository.Entities
{
    public class ExperimentalContext : DbContext
    {
        public ExperimentalContext() :   base("EmployeeDBContext")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
