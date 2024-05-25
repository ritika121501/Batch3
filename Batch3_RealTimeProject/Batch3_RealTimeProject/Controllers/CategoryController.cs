using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch3_RealTimeProject.Controllers
{
    public class CategoryController : Controller

    {
        private readonly IGenericRepo<Category> _genericRepoCate;
        public CategoryController(IGenericRepo<Category> genericRepoCate)
        {
            _genericRepoCate = genericRepoCate;
        }

        [HttpGet]

        public IActionResult ShowCategoryList()
        {
            var listOfCate = _genericRepoCate.GetAll();
            return View(listOfCate);
        }

        [HttpGet]

        public JsonResult ShowCategoryList1()
        {
            var listOfCate = _genericRepoCate.GetAll();
            return Json(listOfCate);
        }
        //tempdata/ ViewBag/Viewdata
        //Http Verbs

        //what are the different state management techniques in mvc? -- Tempdata/ViewBag/ViewData/Query string/SEssions/Cookies

        //two way binding

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category cate)
        {
            _genericRepoCate.Create(cate);

            TempData["Success"] = "Category Created Successfully";

            return RedirectToAction("ShowCategoryList");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            return View(_genericRepoCate.GetById(id));
        }

        [HttpPost]

        public IActionResult EditCategory(Category category)
        {
            _genericRepoCate.Update(category);
            TempData["Success"] = "Category Updated Successfully";
            return RedirectToAction("ShowCategoryList");
        }



        //[HttpGet]

        //public IActionResult Delete(int id)

        //{

        //    _genericRepoCate.DeleteById(id);

        //    return RedirectToAction("ShowCategoryList");

        //}

    }

}