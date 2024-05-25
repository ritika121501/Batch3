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
        private readonly IGenericRepo<ProductImage> _productImageRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IGenericRepo<Product> productRepo, IGenericRepo<Category> categoryRepo,
            IWebHostEnvironment webHostEnvironment, IGenericRepo<ProductImage> productImageRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
            _productImageRepo = productImageRepo;
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
            //example for projections in EF/ anonymous functions/delegates-anonymous functions/ Projections
            IEnumerable<SelectListItem> CategoryList = _categoryRepo.GetAll().Select(u => new SelectListItem
            {
                Text = u.CategoryName,
                Value = u.CategoryId.ToString()
            });
            ViewBag.CategoryList = CategoryList;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product, IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productImagePath = Path.Combine(wwwRootPath, @"Images\Product");

                //what is the purpose using block
                //using statement internally calls IDisposable which will make sure that 
                //the resource that has been consumed during sqlConnectiom, Filestream, or memory stream
                //will be freed up -- GC get invoked
                using (var fileStream = new FileStream(Path.Combine(productImagePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                product.ProductImageUrl = @"\Images\Product\" + fileName;
            }

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
        public IActionResult EditProduct(Product product, IFormFile file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string productImagePath = Path.Combine(wwwRootPath, @"Images\Product");
            var productImage = new ProductImage();
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            if (!String.IsNullOrEmpty(product.ProductImageUrl))
            {
                var oldPath = Path.Combine(productImagePath, product.ProductImageUrl);

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                using (var fileStream = new FileStream(Path.Combine(productImagePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                product.ProductImageUrl = @"\Images\Product\" + fileName;
            }
            productImage.ProductId = product.Id;
            productImage.ImageUrl = product.ProductImageUrl = @"\Images\Product\" + fileName;
            _productImageRepo.Create(productImage);
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
