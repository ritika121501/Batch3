using Batch3_RealTimeProject.DAL;
using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Batch3_RealTimeProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepo<Product> _productRepo;
        private readonly IGenericRepo<Category> _categoryRepo;

        public ProductController(IGenericRepo<Product> productRepo, IGenericRepo<Category> categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }


        // GET: ProductController
        [HttpGet]
        public IActionResult ShowProductList()
        {
            var listofproduct = _productRepo.GetAll();
            return View(listofproduct);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            //example for projections in EF/ anonymous functions/delegates-anonymous functions
            IEnumerable<SelectListItem> CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryId.ToString()
            });
            ViewBag.CategoryList = CategoryList;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productRepo.Create(product);
            TempData["Success"] = "Product Created Successfully";
            return RedirectToAction("ShowProductList");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var product = _productRepo.GetById(id);
            IEnumerable<SelectListItem> CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryId.ToString()
            });
            ViewBag.CategoryList = CategoryList;
            if (product == null)
            {
                return NotFound();

            }
            return View(product);

        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _productRepo.Update(product);
            TempData["Success"] = "Product Updated Successfully";
            return RedirectToAction("ShowProductList");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            var deleteProduct = _productRepo.GetById(id);
            if (deleteProduct == null)
            {
                return NotFound();

            }
            _productRepo.DeleteById(deleteProduct);
            return RedirectToAction("ShowProductList");

        }
    }
}
