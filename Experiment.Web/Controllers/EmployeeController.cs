using Experiment.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experiment.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _employeeLogic.GetAllActive();
            var employeesVM = ModelMapper.Mapper.MapEntities<Experiment.Models.DomainModels.Employee, Models.EmployeeViewModel>(employees);
            return View(employeesVM);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = _employeeLogic.GetByID(id);
            var employeeVM = ModelMapper.Mapper.MapEntity<Experiment.Models.DomainModels.Employee, Models.EmployeeViewModel>(employee);
            return View(employeeVM);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Models.EmployeeViewModel employeeVM)
        {
            try
            {
                // TODO: Add insert logic here
                var employee = ModelMapper.Mapper.MapEntity<Models.EmployeeViewModel, Experiment.Models.DomainModels.Employee>(employeeVM);

                _employeeLogic.Save(employee);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employeeLogic.GetByID(id);
            var employeeVM = ModelMapper.Mapper.MapEntity<Experiment.Models.DomainModels.Employee, Models.EmployeeViewModel>(employee);
            return View(employeeVM);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.EmployeeViewModel employeeVM)
        {
            try
            {
                var employee = ModelMapper.Mapper.MapEntity<Models.EmployeeViewModel, Experiment.Models.DomainModels.Employee>(employeeVM);

                _employeeLogic.Save(employee);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
