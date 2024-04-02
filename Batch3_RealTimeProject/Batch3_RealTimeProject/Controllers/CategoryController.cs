using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch3_RealTimeProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericRepo<Category> _categoryRepo;

        public CategoryController(IGenericRepo<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }


        // GET: ProductController
        [HttpGet]
        public IActionResult ShowCategoryList()
        {
            var listOfCategory = _categoryRepo.GetAll();
            return View(listOfCategory);
        }
        

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryRepo.Create(category);
            return RedirectToAction("ShowCategoryList");
        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var category = _categoryRepo.GetById(id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);

        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _categoryRepo.Update(category);
            return RedirectToAction("ShowCategoryList");
        }
    }
}
