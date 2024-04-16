using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch3_RealTimeProject.Controllers
{
    public class CompanyController : Controller
    {

        private readonly IGenericRepo<Company> _genericRepoComp;
        public CompanyController(IGenericRepo<Company> genericRepoComp)
        {
            _genericRepoComp = genericRepoComp;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Code to show the list of Companies
        [HttpGet]
        public IActionResult ShowCompanyList()
        {
            var listOfComp = _genericRepoComp.GetAll();
            return View(listOfComp);
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
        //public JsonResult GetCompany()
        //{
        //    Company company = new Company();
        //    company.Address = new Address();
        //    company.Address.PhoneNumber = "454654";
        //    company.Address.AddressLine1 = "ABC";
        //    company.CompanyName = "Test";
        //    return Json(company);
        //}

        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCompany(Company comp)
        {
            _genericRepoComp.Create(comp);

            TempData["Success"] = "Company Created Successfully";

            return RedirectToAction("ShowCompanyList");
        }
        [HttpGet]
        public IActionResult EditCompany(int id)
        {
            return View(_genericRepoComp.GetById(id));
        }

        [HttpPost]

        public IActionResult EditCompany(Company company)
        {
            _genericRepoComp.Update(company);
            TempData["Success"] = "Company Updated Successfully";
            return RedirectToAction("ShowCompanyList");
        }
        //[HttpGet]

        //public IActionResult Delete(int id)

        //{

        //    _genericRepoCate.DeleteById(id);

        //    return RedirectToAction("ShowCategoryList");

        //}







    }
}