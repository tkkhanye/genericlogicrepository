using Experiment.Models.BusinessLogic;
using Experiment.Models.DomainModels;
using Experiment.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.BusinessLogic
{
    public class EmployeeLogic : GenericLogic<Employee>, IEmployeeLogic
    {
        public EmployeeLogic(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.EmployeeRepository) {}
    }
}
