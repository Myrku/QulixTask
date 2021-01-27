using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QulixTask.DB;
using QulixTask.Models;

namespace QulixTask.Controllers
{
    public class CompanyController : Controller
    {
        DbConnection dbConnection;

        public CompanyController()
        {
            dbConnection = new DbConnection();
        }

        public IActionResult Сompanies()
        {
            List<Company> companies = dbConnection.GetAllCompanies().Result;
            return View(companies);
        }

        [HttpPost]
        public IActionResult CreateCompany(Company company)
        {
                dbConnection.AddCompany(company);
                return RedirectToAction("Сompanies");            
        }

        [HttpGet]
        public IActionResult DeleteCompany(int id)
        {
            dbConnection.DeleteCompany(id);
            return RedirectToAction("Сompanies");
        }

        [HttpPost]
        public IActionResult UpdateCompany(Company company)
        {
            dbConnection.UpdateCompany(company);
            return RedirectToAction("Сompanies");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
