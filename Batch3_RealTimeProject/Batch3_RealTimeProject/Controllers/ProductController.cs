using Batch3_RealTimeProject.DAL;
using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch3_RealTimeProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepo<Product> _productRepo;

        public ProductController(IGenericRepo<Product> productRepo)
        {
            _productRepo = productRepo;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _productRepo.Create(product);
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
            return RedirectToAction("ShowProductList");
        }

        //[HttpGet]
        //public IActionResult DeleteProduct(int id)
        //{
        //    var deleteProduct = _productRepo.GetById(id);
        //    if (deleteProduct == null)
        //    {
        //        return NotFound();

        //    }
        //    _productRepo.Delete(deleteProduct);
        //    return RedirectToAction("ShowProductList");

        //}
    }
}
