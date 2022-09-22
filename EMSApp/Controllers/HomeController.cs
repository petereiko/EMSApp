using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMSApp.Models;

namespace EMSApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Employee employee = new Employee
            {
                Age = 34,
                Name = "Peter"
            };

            Department dept = new Department
            {
                Id = 1,
                Name = "IT"
            };

            Result result = new Result
            {
                Department = dept,
                Employee = employee
            };

            ViewBag.Display = employee;
            ViewData["Department"] = dept;
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EmployeeList()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{ Age=30, Name="Peter"},
                new Employee{ Age=31, Name="Peter1"},
                new Employee{ Age=32, Name="Peter2"},
                new Employee{ Age=33, Name="Peter3"},
                new Employee{ Age=34, Name="Peter4"},
            };

            return View(employees);
        }

        [HttpGet]
        public ActionResult Register()
        {
            List<Department> departments = GetDepartments();
            ViewBag.Departments = departments;
            Employee employee = new Employee() { Age = 35, Name = "Mark", DepartmentId = 4 };
            return View(employee);
        }

        [HttpPost]
        public ActionResult Register(Employee employee)
        {
            return View();
        }


        private List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>
            {
                new Department{ Id=1, Name="IT"},
                new Department{ Id=2, Name="Risk"},
                new Department{ Id=3, Name="Telecoms"},
                new Department{ Id=4, Name="HR"},
                new Department{ Id=5, Name="Management"}
            };

            return departments;
        }
    }
}