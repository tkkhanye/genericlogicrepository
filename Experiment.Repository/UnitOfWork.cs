using Experiment.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context = null;

        private Lazy<GenericRepository<Models.DomainModels.Employee, Entities.Employee>> _employeeRepository;
        private Lazy<GenericRepository<Models.DomainModels.Department, Entities.Department>> _departmentRepository;

        public UnitOfWork()
        {
            context = new Entities.ExperimentalContext();
            InitializeLazies();
        }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
            InitializeLazies();
        }

        public IGenericRepository<Models.DomainModels.Employee> EmployeeRepository
        {
            get
            {
                return _employeeRepository.Value;
            }
        }

        public IGenericRepository<Models.DomainModels.Department> DepartmentRepository
        {
            get
            {
                return _departmentRepository.Value;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Private Methods
        private void InitializeLazies()
        {
            _employeeRepository = new Lazy<GenericRepository<Models.DomainModels.Employee, Entities.Employee>>(() => new GenericRepository<Models.DomainModels.Employee, Entities.Employee>().Initialize(context));
            _departmentRepository = new Lazy<GenericRepository<Models.DomainModels.Department, Entities.Department>>(() => new GenericRepository<Models.DomainModels.Department, Entities.Department>().Initialize(context));
        }
        #endregion  
    }
}
