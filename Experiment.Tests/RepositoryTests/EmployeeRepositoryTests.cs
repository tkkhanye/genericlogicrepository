using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Data.Entity;
using Experiment.Repository;

namespace Experiment.Tests.RepositoryTests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        [TestMethod]
        public void EmployeeRepository_GetFirst_ShouldPass()
        {
            var context = MockRepository.GenerateStub<DbContext>();
            var dbset = MockRepository.GenerateStub<DbSet<Repository.Entities.Employee>>();
            var employeeReturned = new Repository.Entities.Employee { ID = 1, Active = true, FirstName = "First" }; 

            context.Expect(x => x.Set<Repository.Entities.Employee>()).Return(dbset);
            dbset.Stub(x => x.Find(1)).Return(employeeReturned);

            var unitOfWork = new UnitOfWork(context);
            var employeeRepo = unitOfWork.EmployeeRepository;

            var employee = employeeRepo.GetByID(1);

            Assert.IsNotNull(employee);
            Assert.IsTrue(employee.ID == employeeReturned.ID);
            Assert.IsTrue(employee.FirstName == employeeReturned.FirstName);
        }
    }
}
