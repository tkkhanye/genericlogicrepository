using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Models.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<DomainModels.Employee> EmployeeRepository { get; }
        IGenericRepository<DomainModels.Department> DepartmentRepository { get; }

        void Save();
    }
}
