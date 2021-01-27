using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QulixTask.DB;
using QulixTask.Models;

namespace QulixTask.Controllers
{
    public class EmployeeController : Controller
    {
        DbConnection dbConnection;
        public EmployeeController()
        {
            dbConnection = new DbConnection();
        }
        public IActionResult Employees()
        {
            List<Company> companies = dbConnection.GetAllCompanies().Result;
            ViewBag.companies = companies;
            return View(dbConnection.GetAllEmployees().Result);
        }
        public IActionResult CreateEmployee(Employee employee)
        {
            dbConnection.AddEmployee(employee);
            return RedirectToAction("Employees");
        }
        public IActionResult DeleteEmployee(int id)
        {
            dbConnection.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }

        public IActionResult UpdateEmployee(Employee employee)
        {
            dbConnection.UpdateEmployee(employee);
            return RedirectToAction("Employees");
        }
    }
}
