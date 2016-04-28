using Experiment.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Models.BusinessLogic
{
    public interface IEmployeeLogic
    {
        Employee GetByID(int ID);

        List<Employee> GetAllActive();

        void Save(Employee employee);
    }
}
