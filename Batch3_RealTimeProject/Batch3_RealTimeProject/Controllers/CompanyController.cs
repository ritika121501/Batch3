using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch3_RealTimeProject.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //MVC

        //1) MVC life cycle
        //2) TempData, ViewBag and ViewData -- differnt ways of session management in mvc
        //3) IActionResult and various types
        //4) difference between MVC controller and API Controller
        //5) Error handling in mvc
        //6) filters in mvc - action/authorization/exception/authentication
        //7) can we have multiple layout pages in mvc -- yes but it has to be referred specifically
        //8) can we have multiple models in a view - no no no
        //9) have you used jquery to connect to ui to controller
        //10) Suppose i have a grid, and i would like to refresh the grid data without refreshing the page - AJAX calls
        public JsonResult GetCompany()
        {
            Company company = new Company();
            company.Address = new Address();
            company.Address.PhoneNumber = "454654";
            company.Address.AddressLine1 = "ABC";
            company.CompanyName = "Test";
            return Json(company);
        }
    }
}
