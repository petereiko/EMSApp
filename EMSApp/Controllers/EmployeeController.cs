using EMSApp.EntityModels;
using EMSApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMSApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EMSAppDbContext db = new EMSAppDbContext();

            List<Employee> employees = db.Employees.ToList();

            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel model) 
        {
            try
            {
                EMSAppDbContext db = new EMSAppDbContext();

                Employee emp = new Employee
                {
                    Address = model.Address,
                    DateCreated = DateTime.Now,
                    Email = model.Email,
                    Salary = model.Salary,
                    IsActive = true,
                    Phone = model.Phone
                };

                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred while trying to create your profile";
            }

            return View();
        }


        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("Error");
            int ID= Helper.Decrypt(id);
            EMSAppDbContext db = new EMSAppDbContext();
            Employee employee = db.Employees.FirstOrDefault(x => x.Id == ID);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee model) 
        {
            try
            {
                EMSAppDbContext db = new EMSAppDbContext();

                var originalEmployee = db.Employees.FirstOrDefault(x => x.Id == model.Id);
                originalEmployee.Address = model.Address;
                originalEmployee.Email = model.Email;
                originalEmployee.Salary = model.Salary;
                originalEmployee.Phone = model.Phone;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            { 

                ViewBag.Error = "An error occurred while trying to edit employee record";
            }
            
            return View(model);
        }

        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("Error");
            int ID= Helper.Decrypt(id);
            EMSAppDbContext db = new EMSAppDbContext();
            Employee employee = db.Employees.FirstOrDefault(x => x.Id == ID);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                EMSAppDbContext db = new EMSAppDbContext();

                Employee emp = db.Employees.FirstOrDefault(x => x.Id == employee.Id);
                db.Employees.Remove(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred while trying to delete employee record";

            }
            return View(employee);
        }

    }
}