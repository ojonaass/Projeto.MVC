using Projeto.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private List<Employee> employeesList = new List<Employee>();

        private List<Employee> CarregarDadosEmployee()
        {
            employeesList.Add(new Employee
            {
                Empid = 1,
                Name = "Sato",
                City = "Campo Grande",
                Address = "Kame Takaiassu",

            });
            Session["employeesList"] = employeesList;
            return employeesList;
        }

        // GET: Employee
        public ActionResult GetAllEmpDetails()
        {
            ModelState.Clear();
            employeesList = (List<Employee>)Session["employeesList"];
            return View(employeesList);
        }

        // GET: Employee/Details/5
        public ActionResult AddEmployee()
        {
            if (employeesList.Count == 0)
            {
                CarregarDadosEmployee();
            }
            Session["employeesList"] = employeesList;
            return View();
        }



        // POST: Employee/Create
        [HttpPost]
        public ActionResult AddEmployee(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeesList = (List<Employee>)Session["employeesList"];
                    var employee = new Employee();

                    //[Serializable ]

                    employee.Empid = employeesList.Count + 1;
                    employee.Name = collection["Name"];
                    employee.City = collection["City"];
                    employee.Address = collection["Address"];


                    employeesList.Add(employee);
                    Session["employeesList"] = employeesList;
                    ViewBag.Message = "Employee details added successfully";


                    //return employeesList;
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult EditEmpDetails()
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditEmpDetails(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add Delete logic here
                ViewBag.AlertMsg = "Employee details deleted successfully";
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }
    }
}
