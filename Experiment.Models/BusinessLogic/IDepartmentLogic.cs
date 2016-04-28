using Experiment.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Models.BusinessLogic
{
    public interface IDepartmentLogic
    {
        Department GetByID(int ID);

        List<Department> GetAllActive();

        void Save(Department employee);
    }
}
