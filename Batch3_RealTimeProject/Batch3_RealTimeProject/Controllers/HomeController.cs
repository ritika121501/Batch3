using Batch3_RealTimeProject.DAL.Repository;
using Batch3_RealTimeProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Batch3_RealTimeProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepo<Product> _productRepo;
        private readonly IGenericRepo<ShoppingCart> _shoppingCartRepo;
        private readonly IGenericRepo<ProductImage> _productImageRepo;
        private readonly IGenericRepo<Category> _categoryRepo;

        public HomeController(ILogger<HomeController> logger, IGenericRepo<Product> productRepo, IGenericRepo<ProductImage> productImageRepo, IGenericRepo<ShoppingCart> shoppingCartrepo, IGenericRepo<Category> categoryRepo)
        {
            _productRepo = productRepo;
            _productImageRepo = productImageRepo;
            _logger = logger;
            _shoppingCartRepo = shoppingCartrepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> result;

            var products = _productRepo.GetByIdForList();


            return View(products);

        }

        [HttpGet]
        public IActionResult Details(int productId)
        {
            var shoppinngCart = new ShoppingCart();
            shoppinngCart.ProductId = productId;
            var product = _productRepo.GetById(productId);
            shoppinngCart.Product = product;
            shoppinngCart.Product.Category = _categoryRepo.GetById(product.CategoryId);
            shoppinngCart.Product.ProductImages = _productImageRepo.GetAll().ToList();

            return View(shoppinngCart);
        }

        [HttpPost]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            //temp implementation - this will change on tuesday once identity scaffolding is completed
            var userId = "Ritika123";
            shoppingCart.UserId = userId;
            var cartData = _shoppingCartRepo.Get(u => u.UserId == userId && u.ProductId == shoppingCart.ProductId);
            if (cartData != null)
            {
                cartData.Count = cartData.Count + shoppingCart.Count;
                _shoppingCartRepo.Update(cartData);
            }
            else
            {
                _shoppingCartRepo.Create(shoppingCart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
