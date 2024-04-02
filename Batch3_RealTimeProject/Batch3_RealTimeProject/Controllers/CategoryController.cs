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

        //Http Verbs

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