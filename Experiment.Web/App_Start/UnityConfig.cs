using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Experiment.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            RegisterServices(container);
            RegisterRepositories(container);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterServices(UnityContainer container)
        {
            container.RegisterType<Experiment.Models.BusinessLogic.IEmployeeLogic, BusinessLogic.EmployeeLogic>();
            container.RegisterType<Experiment.Models.BusinessLogic.IDepartmentLogic, BusinessLogic.DepartmentLogic>();
        }

        private static void RegisterRepositories(UnityContainer container)
        {
            container.RegisterType<Experiment.Models.Repository.IUnitOfWork, Repository.UnitOfWork>();
        }
    }
}